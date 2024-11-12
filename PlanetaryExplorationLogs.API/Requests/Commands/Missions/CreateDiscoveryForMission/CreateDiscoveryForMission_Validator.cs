using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Validator : ValidatorBase
    {
        private readonly int _missionId;
        private readonly Discovery _discovery;

        public CreateDiscoveryForMission_Validator(PlanetExplorationDbContext context, int missionId, Discovery discovery)
            : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Check if mission exists
            var missionExists = await DbContext.Missions
                .AnyAsync(m => m.Id == _missionId);

            if (!missionExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission with ID {_missionId} not found.");
            }

            // Check if discovery type exists
            var discoveryTypeExists = await DbContext.DiscoveryTypes
                .AnyAsync(dt => dt.Id == _discovery.DiscoveryTypeId);

            if (!discoveryTypeExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    $"DiscoveryType with ID {_discovery.DiscoveryTypeId} not found.");
            }

            // Validate name
            if (string.IsNullOrWhiteSpace(_discovery.Name))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery name is required.");
            }

            if (_discovery.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Discovery name cannot exceed 150 characters.");
            }

            // Check for duplicate discovery names within this mission
            var duplicateExists = await DbContext.Discoveries
                .AnyAsync(d => d.MissionId == _missionId &&
                              d.Name.ToLower() == _discovery.Name.ToLower());

            if (duplicateExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "A discovery with this name already exists for this mission.");
            }

            return await ValidResultAsync();
        }
    }
}
