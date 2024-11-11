using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Data.Models;
using System.Reflection;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission
{
    public class UpdateMission_Command : RequestBase<int>
    {
        private readonly int _id;
        private readonly Mission _mission;

        public UpdateMission_Command(PlanetExplorationDbContext context, int id, Mission mission)
            : base(context)
        {
            _id = id;
            _mission = mission;
        }

        public override IValidator Validator => new UpdateMission_Validator(DbContext, _id, _mission);
        public override IHandler<int> Handler => new UpdateMission_Handler(DbContext, _id, _mission);
    }
}
