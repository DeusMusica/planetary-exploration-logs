using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Validator : ValidatorBase
    {
        private readonly int _id;
        private readonly Discovery _discovery;

        public UpdateDiscovery_Validator(PlanetExplorationDbContext context, int id, Discovery discovery)
            : base(context)
        {
            _id = id;
            _discovery = discovery;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Check if the Discovery exists
            var existingDiscovery = await DbContext.Discoveries.FindAsync(_id);
            if (existingDiscovery == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "The discovery with the provided ID does not exist.");
            }

            // Only validate name if it's being updated
            if (!string.IsNullOrEmpty(_discovery.Name) && _discovery.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "The discovery name cannot exceed 150 characters.");
            }

            // Validate MissionId if it's being updated
            if (_discovery.MissionId != 0)
            {
                var missionExists = await DbContext.Missions.AnyAsync(m => m.Id == _discovery.MissionId);
                if (!missionExists)
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The specified Mission does not exist.");
                }
            }

            // Validate DiscoveryTypeId if it's being updated
            if (_discovery.DiscoveryTypeId != 0)
            {
                var typeExists = await DbContext.DiscoveryTypes.AnyAsync(t => t.Id == _discovery.DiscoveryTypeId);
                if (!typeExists)
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The specified DiscoveryType does not exist.");
                }
            }

            return await ValidResultAsync();
        }
    }
}
