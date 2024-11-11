using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscovery
{
    public class DeleteDiscovery_Command : RequestBase<int>
    {
        private readonly int _id;

        public DeleteDiscovery_Command(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override IValidator Validator => new DeleteDiscovery_Validator(DbContext, _id);
        public override IHandler<int> Handler => new DeleteDiscovery_Handler(DbContext, _id);
    }
}
