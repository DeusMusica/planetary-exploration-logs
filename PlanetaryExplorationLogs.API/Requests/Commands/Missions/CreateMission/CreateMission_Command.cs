using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.Models;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission
{
    public class CreateMission_Command : RequestBase<int>
    {
        private readonly Mission _mission;

        public CreateMission_Command(PlanetExplorationDbContext context, Mission mission)
            : base(context)
        {
            _mission = mission;
        }

        public override IValidator Validator => new CreateMission_Validator(DbContext, _mission);
        public override IHandler<int> Handler => new CreateMission_Handler(DbContext, _mission);
    }
}
