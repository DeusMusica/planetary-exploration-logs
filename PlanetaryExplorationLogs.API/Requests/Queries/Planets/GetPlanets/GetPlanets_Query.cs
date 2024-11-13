using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Planets;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Planets.GetPlanets
{
    public class GetPlanets_Query : RequestBase<List<PlanetListItemDto>>
    {
        public GetPlanets_Query(PlanetExplorationDbContext context) 
            : base(context) 
        {
        }

        public override IHandler<List<PlanetListItemDto>> Handler => new GetPlanets_Handler(DbContext);
    }
}
