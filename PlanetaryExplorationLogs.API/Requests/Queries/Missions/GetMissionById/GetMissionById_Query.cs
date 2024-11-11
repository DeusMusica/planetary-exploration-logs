
using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById
{
    public class GetMissionById_Query : RequestBase<MissionDto>
    {
        private readonly int _id;

        public GetMissionById_Query(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override IValidator Validator => new GetMissionById_Validator(DbContext, _id);

        public override IHandler<MissionDto> Handler => new GetMissionById_Handler(DbContext, _id);
    }
}

