using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Planets;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanets
{
    public class GetPlanets_Handler : HandlerBase<List<PlanetListItemDto>>
    {
        public GetPlanets_Handler(PlanetExplorationDbContext context)
            : base(context) 
        {
        }

        public override async Task<RequestResult<List<PlanetListItemDto>>> HandleAsync()
        {
            // Fetch all planets and map to PlanetDto
            var planets = await DbContext.Planets
                .Select(p => new PlanetListItemDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Type = p.Type,
                    Climate = p.Climate,
                    Terrain = p.Terrain,
                    Population = p.Population
                })
                .ToListAsync();

            return new RequestResult<List<PlanetListItemDto>>
            {
                Data = planets,
                StatusCode = HttpStatusCode.OK,
                Message = "Planets retrieved successfully."
            };
        }
    }
}
