using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using System.Net;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.DeleteDiscovery
{
    public class DeleteDiscovery_Handler : HandlerBase<int>
    {
        private readonly int _id;

        public DeleteDiscovery_Handler(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            try
            {
                // Get the discovery
                var discovery = await DbContext.Discoveries.FindAsync(_id);

                // This shouldn't typically happen since validator checks for existence,
                // but it's good practice to handle race conditions
                if (discovery == null)
                {
                    return new RequestResult<int>
                    {
                        Data = -1,
                        StatusCode = HttpStatusCode.NotFound,
                        Message = $"Discovery with ID {_id} not found"
                    };
                }

                // Remove the discovery
                DbContext.Discoveries.Remove(discovery);
                await DbContext.SaveChangesAsync();

                // Return success result
                return new RequestResult<int>
                {
                    Data = _id,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Discovery deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error deleting discovery: {ex.Message}"
                };
            }
        }
    }
}
