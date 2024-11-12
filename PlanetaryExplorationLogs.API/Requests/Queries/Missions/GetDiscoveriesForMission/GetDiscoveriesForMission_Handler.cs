using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Discovery;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Handler : HandlerBase<List<DiscoveryDto>>
    {
        private readonly int _missionId;

        public GetDiscoveriesForMission_Handler(PlanetExplorationDbContext context, int missionId)
            : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult<List<DiscoveryDto>>> HandleAsync()
        {
            try
            {
                var discoveries = await DbContext.Discoveries
                    .Include(d => d.DiscoveryType)
                    .Include(d => d.Mission)
                    .Where(d => d.MissionId == _missionId)
                    .Select(d => new DiscoveryDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        Location = d.Location,
                        DiscoveryTypeId = d.DiscoveryTypeId,
                        MissionId = d.MissionId,
                        Mission = new MissionDto
                        {
                            Id = d.Mission.Id,
                            Name = d.Mission.Name,
                            Date = d.Mission.Date,
                            PlanetId = d.Mission.PlanetId,
                            Description = d.Mission.Description,
                            PlanetName = d.Mission.Planet.Name
                        },
                        DiscoveryType = new DiscoveryTypeDto
                        {
                            Id = d.DiscoveryType.Id,
                            Name = d.DiscoveryType.Name,
                            Description = d.DiscoveryType.Description
                        }
                    })
                    .ToListAsync();

                return new RequestResult<List<DiscoveryDto>>
                {
                    Data = discoveries,
                    StatusCode = HttpStatusCode.OK,
                    Message = discoveries.Any()
                        ? $"Successfully retrieved discoveries for mission {_missionId}"
                        : $"No discoveries found for mission {_missionId}"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<List<DiscoveryDto>>
                {
                    Data = null,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error retrieving discoveries for mission {_missionId}: {ex.Message}"
                };
            }
        }
    }
}
