using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscovery
{
    public class DeleteDiscovery_Validator : ValidatorBase
    {
        private readonly int _id;

        public DeleteDiscovery_Validator(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            // Check if the Discovery exists
            var discovery = await DbContext.Discoveries
                .Include(d => d.Mission)
                .FirstOrDefaultAsync(d => d.Id == _id);

            if (discovery == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Discovery with ID {_id} not found.");
            }

            return await ValidResultAsync();
        }
    }
}
