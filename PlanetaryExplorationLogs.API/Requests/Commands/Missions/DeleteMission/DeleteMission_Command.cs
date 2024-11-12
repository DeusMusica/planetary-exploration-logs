using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Command : RequestBase<int>
    {
        private readonly int _id;

        public DeleteMission_Command(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override IValidator Validator => new DeleteMission_Validator(DbContext, _id);
        public override IHandler<int> Handler => new DeleteMission_Handler(DbContext, _id);
    }
}
