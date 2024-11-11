using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Command : RequestBase<int>
		{
        private readonly int _id;
        private readonly Discovery _discovery;

        public UpdateDiscovery_Command(PlanetExplorationDbContext context, int id, Discovery discovery)
            : base(context)
        {
            _id = id;
            _discovery = discovery;
        }

        public override IValidator Validator => new UpdateDiscovery_Validator(DbContext, _id, _discovery);

        public override IHandler<int> Handler => new UpdateDiscovery_Handler(DbContext, _id, _discovery);
    }
}
