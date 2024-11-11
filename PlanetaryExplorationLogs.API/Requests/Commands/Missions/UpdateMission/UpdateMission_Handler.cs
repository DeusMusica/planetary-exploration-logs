using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Handler : HandlerBase<int>
    {
        private readonly int _id;
        private readonly Mission _mission;

        public UpdateMission_Handler(PlanetExplorationDbContext context, int id, Mission mission)
            : base(context)
        {
            _id = id;
            _mission = mission;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            // Fetch the existing mision
            var existingMission = await DbContext.Missions.FindAsync(_id);

            if(existingMission == null) 
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Mission with ID {_id} now found"
                };
            }

            if (_mission.PlanetId != 0)
            {
                existingMission.PlanetId = _mission.PlanetId;
            }

            if (!string.IsNullOrEmpty(_mission.Name))
            {
                existingMission.Name = _mission.Name;
            }

            if (!string.IsNullOrEmpty(_mission.Description))
            {
                existingMission.Description = _mission.Description;
            }
            if (_mission.Date != default(DateTime))
                {
                existingMission.Date = _mission.Date;
            }
            try
            {
                await DbContext.SaveChangesAsync();
                return new RequestResult<int>
                {
                    Data = existingMission.Id,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Mission updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error updating mission: {ex.Message}"
                };
            }
        }
    }
}
