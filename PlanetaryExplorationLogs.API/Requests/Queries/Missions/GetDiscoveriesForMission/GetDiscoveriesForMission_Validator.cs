using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission
{
    public class GetDiscoveriesForMission_Validator : ValidatorBase
    {
        private readonly int _missionId;

        public GetDiscoveriesForMission_Validator(PlanetExplorationDbContext context, int missionId)
            : base(context)
        {
            _missionId = missionId;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var missionExists = await DbContext.Missions
                .AnyAsync(m => m.Id == _missionId);

            if (!missionExists)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission with ID {_missionId} not found.");
            }

            return await ValidResultAsync();
        }
    }
}
