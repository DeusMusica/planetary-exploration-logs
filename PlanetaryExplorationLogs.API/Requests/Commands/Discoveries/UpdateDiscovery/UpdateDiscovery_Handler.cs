using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using System.Net;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Commands.Discoveries.UpdateDiscovery
{
    public class UpdateDiscovery_Handler : HandlerBase<int>
    {
        private readonly int _id;
        private readonly Discovery _discovery;

        public UpdateDiscovery_Handler(PlanetExplorationDbContext context, int id, Discovery discovery)
            : base(context)
        {
            _id = id;
            _discovery = discovery;
        }

        public override async Task<RequestResult<int>> HandleAsync()
        {
            // Fetch the existing discovery
            var existingDiscovery = await DbContext.Discoveries
                .FindAsync(_id);

            if (existingDiscovery == null)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.NotFound,
                    Message = $"Discovery with ID {_id} not found"
                };
            }

            // Update only properties that were included in the request
            if (_discovery.MissionId != 0)
            {
                existingDiscovery.MissionId = _discovery.MissionId;
            }

            if (_discovery.DiscoveryTypeId != 0)
            {
                existingDiscovery.DiscoveryTypeId = _discovery.DiscoveryTypeId;
            }

            if (!string.IsNullOrEmpty(_discovery.Name))
            {
                existingDiscovery.Name = _discovery.Name;
            }

            if (!string.IsNullOrEmpty(_discovery.Description))
            {
                existingDiscovery.Description = _discovery.Description;
            }

            if (!string.IsNullOrEmpty(_discovery.Location))
            {
                existingDiscovery.Location = _discovery.Location;
            }

            try
            {
                await DbContext.SaveChangesAsync();
                return new RequestResult<int>
                {
                    Data = existingDiscovery.Id,
                    StatusCode = HttpStatusCode.OK,
                    Message = "Discovery updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new RequestResult<int>
                {
                    Data = -1,
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = $"Error updating discovery: {ex.Message}"
                };
            }
        }
    }
}
