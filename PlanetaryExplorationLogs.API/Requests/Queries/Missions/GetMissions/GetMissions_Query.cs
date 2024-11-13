using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions
{
    public class GetMissions_Query : RequestBase<List<MissionListItemDto>>
	{
		public GetMissions_Query(PlanetExplorationDbContext context)
			: base(context)
		{
		}

		public override IHandler<List<MissionListItemDto>> Handler => new GetMissions_Handler(DbContext);
	}
}
