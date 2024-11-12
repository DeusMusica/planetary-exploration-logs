using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission
{
    public class DeleteMission_Handler : HandlerBase<int>
    {
        private readonly int _id;

        public DeleteMission_Handler(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            try
            {
                var mission = await DbContext.Missions.FindAsync(_id);

                if (mission == null)
                {
                    return new RequestResult<int>
                    {
                        Data = -1,
                        StatusCode = HttpStatusCode.NotFound,
                        Message = $"Mission with ID {_id} not found"
                    };
                }

                DbContext.Missions.Remove(mission);
                await DbContext.SaveChangesAsync();

                return new RequestResult<int>
                {
                    Data = _id,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Mission deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error deleting mission: {ex.Message}"
                };
            }
        }
    }
}