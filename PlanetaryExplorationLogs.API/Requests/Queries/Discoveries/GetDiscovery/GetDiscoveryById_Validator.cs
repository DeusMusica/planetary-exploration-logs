using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscovery
{
    public class GetDiscoveryById_Validator : ValidatorBase
    {
        private readonly int _id;

        public GetDiscoveryById_Validator(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var discoveriesExsts = await DbContext.Discoveries.AnyAsync(d => d.Id == _id);

            if (!discoveriesExsts)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    "Discovery with the provided ID does not exist."
                    );
            }

            return await ValidResultAsync();
        }
    }
}

