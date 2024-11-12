using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission
{
    public class CreateDiscoveryForMission_Command : RequestBase<int>
    {
        private readonly int _missionId;
        private readonly Discovery _discovery;

        public CreateDiscoveryForMission_Command(PlanetExplorationDbContext context, int missionId, Discovery discovery)
            : base(context)
        {
            _missionId = missionId;
            _discovery = discovery;
        }

        public override IValidator Validator => new CreateDiscoveryForMission_Validator(DbContext, _missionId, _discovery);
        public override IHandler<int> Handler => new CreateDiscoveryForMission_Handler(DbContext, _missionId, _discovery);
    }
}
