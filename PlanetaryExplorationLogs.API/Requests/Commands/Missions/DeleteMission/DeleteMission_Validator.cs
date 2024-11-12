using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Validator :ValidatorBase
    {
        private readonly int _id;

        public DeleteMission_Validator(PlanetExplorationDbContext context, int id)
        : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult> ValidateAsync()
        {
            var mission = await DbContext.Missions
                .Include(m => m.Discoveries)
                .FirstOrDefaultAsync(m => m.Id == _id);

            if (mission == null)
            {
                return await InvalidResultAsync(
                    HttpStatusCode.NotFound,
                    $"Mission with ID {_id} not found.");
            }

            return await ValidResultAsync();
        }
    }
}
