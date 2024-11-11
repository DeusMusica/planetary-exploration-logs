using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Handler : HandlerBase<int>
    {
        private readonly Mission _mission;

        public CreateMission_Handler(PlanetExplorationDbContext context, Mission mission)
            : base(context)
        {
            _mission = mission;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            try
            {
                await DbContext.Missions.AddAsync(_mission);
                await DbContext.SaveChangesAsync();

                return new RequestResult<int>
                {
                    Data = _mission.Id,
                    StatusCode = HttpStatusCode.Created,
                    Message = "Mission created successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error creating mission: {ex.Message}"
                };
            }
        }
    }
}
