using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Handler : HandlerBase<int>
    {
        private readonly int _missionId;
        private readonly Discovery _discovery;

        public CreateDiscoveryForMission_Handler(PlanetExplorationDbContext context, int missionId, Discovery discovery)
            : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            try
            {
                // Ensure the discovery is associated with the correct mission
                _discovery.MissionId = _missionId;

                // Add the discovery
                await DbContext.Discoveries.AddAsync(_discovery);
                await DbContext.SaveChangesAsync();

                return new RequestResult<int>
                {
                    Data = _discovery.Id,
                    StatusCode = HttpStatusCode.Created,
                    Message = $"Discovery successfully created for mission {_missionId}"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error creating discovery: {ex.Message}"
                };
            }
        }
    }
}
