using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Discovery;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Query : RequestBase<List<DiscoveryDto>>
    {
        private readonly int _missionId;

        public GetDiscoveriesForMission_Query(PlanetExplorationDbContext context, int missionId)
            : base(context)
        {
            _missionId = missionId;
        }

        public override IValidator Validator => new GetDiscoveriesForMission_Validator(DbContext, _missionId);
        public override IHandler<List<DiscoveryDto>> Handler => new GetDiscoveriesForMission_Handler(DbContext, _missionId);
    }
}
