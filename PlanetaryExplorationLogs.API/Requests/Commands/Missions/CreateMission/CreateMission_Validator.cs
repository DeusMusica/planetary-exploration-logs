using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Validator : ValidatorBase
    {
        private readonly Mission _mission;

        public CreateMission_Validator(PlanetExplorationDbContext context, Mission mission)
            : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(_mission.Name))
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission name is required.");
            }

            if (_mission.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission name cannot exceed 150 characters.");
            }

            if (_mission.Description?.Length > 500)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "Mission description cannot exceed 500 characters.");
            }

            // Check if planet exists
            var planetExists = await DbContext.Planets
                .AnyAsync(p => p.Id == _mission.PlanetId);

            if (!planetExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    $"Planet with ID {_mission.PlanetId} does not exist.");
            }

            // Check for duplicate mission names
            var duplicateExists = await DbContext.Missions
                .AnyAsync(m => m.Name.ToLower() == _mission.Name.ToLower());

            if (duplicateExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "A mission with this name already exists.");
            }

            return await ValidResultAsync();
        }
    }
}
