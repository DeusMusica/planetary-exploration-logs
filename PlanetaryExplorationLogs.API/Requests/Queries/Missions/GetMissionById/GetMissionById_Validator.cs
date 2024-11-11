using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Validator : ValidatorBase
    {
        private readonly int _id;

        public GetMissionById_Validator(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var exists = await DbContext.Missions.AnyAsync(m => m.Id == _id);

            if (!exists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission with ID {_id} not found.");
            }

            return await ValidResultAsync();
        }
    }
}
