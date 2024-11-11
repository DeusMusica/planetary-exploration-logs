using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Handler : HandlerBase<MissionDto>
    {
        private readonly int _id;

        public GetMissionById_Handler(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<MissionDto>> HandleAsync()
        {
            try
            {
                var mission = await DbContext.Missions
                    .Include(m => m.Planet)
                    .Include(m => m.Discoveries)
                        .ThenInclude(d => d.DiscoveryType)
                    .FirstOrDefaultAsync(m => m.Id == _id);

                if (mission == null)
                {
                    return new RequestResult<MissionDto>
                    {
                        Data = null,
                        StatusCode = HttpStatusCode.NotFound,
                        Message = $"Mission with ID {_id} not found"
                    };
                }

                var missionDto = new MissionDto
                {
                    Id = mission.Id,
                    Name = mission.Name,
                    Date = mission.Date,
                    PlanetId = mission.PlanetId,
                    Description = mission.Description,
                    PlanetName = mission.Planet?.Name ?? "Unknown"
                };

                return new RequestResult<MissionDto>
                {
                    Data = missionDto,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Mission retrieved successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<MissionDto>
                {
                    Data = null,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error retrieving mission: {ex.Message}"
                };
            }
        }
    }
}
