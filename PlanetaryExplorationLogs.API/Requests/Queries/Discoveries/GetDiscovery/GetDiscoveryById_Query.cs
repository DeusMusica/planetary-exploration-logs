
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Data.DTO;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscovery
{
    public class GetDiscoveryById_Query : RequestBase<DiscoveryDto>
    {
        private readonly int _id;

        public GetDiscoveryById_Query(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override IValidator Validator => new GetDiscoveryById_Validator(DbContext, _id);

        public override IHandler<DiscoveryDto> Handler => new GetDiscoveryById_Handler(DbContext, _id);

    }
}
