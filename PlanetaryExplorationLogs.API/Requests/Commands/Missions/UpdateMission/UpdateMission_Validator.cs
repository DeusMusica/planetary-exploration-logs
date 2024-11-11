using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Validator : ValidatorBase
    {
        private readonly int _id;
        private readonly Mission _mission;

        public UpdateMission_Validator(PlanetExplorationDbContext context, int id, Mission mission)
            : base(context)
        {
            _id = id;
            _mission = mission;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Check if the Discovery exists
            var existingMission = await DbContext.Missions.FindAsync(_id);
            if (existingMission == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "The discovery with the provided ID does not exist.");
            }

            // Only validate name if it's being updated
            if (!string.IsNullOrEmpty(_mission.Name) && _mission.Name.Length > 150)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.BadRequest,
                    "The discovery name cannot exceed 150 characters.");
            }

            // Validate MissionId if it's being updated
            if (_mission.PlanetId != 0)
            {
                var planetExists = await DbContext.Missions.AnyAsync(m => m.Id == _mission.PlanetId);
                if (!planetExists)
                {
                    return await InvalidResultAsync(
                        HttpStatusCode.BadRequest,
                        "The specified Mission does not exist.");
                }
            }

            return await ValidResultAsync();
        }
    }
}
