using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Discoveries.GetDiscovery
{
    public class GetDiscoveryById_Handler : HandlerBase<DiscoveryDto>
    {
        private readonly int _id;

        public GetDiscoveryById_Handler(PlanetExplorationDbContext context, int id)
            : base(context)
        {
            _id = id;
        }

        public override async Task<RequestResult<DiscoveryDto>> HandleAsync()
        {
            // Obviously, this is a dummy query. Replace it with your own.
            // Write your query here
            var discovery = await DbContext.Discoveries
                .Include(d => d.Mission) // Load related Mission
                .Include(d => d.DiscoveryType) // Load related DiscoveryType
                .Where(d => d.Id == _id)
                .Select(d => new DiscoveryDto
                {
                    Id = d.Id,
                    MissionId = d.MissionId,
                    DiscoveryTypeId = d.DiscoveryTypeId,
                    Name = d.Name,
                    Description = d.Description,
                    Location = d.Location,
                    Mission = new MissionDto
                    {
                        Id = d.Mission.Id,
                        Name = d.Mission.Name,
                        Date = d.Mission.Date,
                        PlanetId = d.Mission.PlanetId,
                        Description = d.Mission.Description,
                        PlanetName = d.Mission.Planet.Name // Include Planet name if necessary
                    },
                    DiscoveryType = new DiscoveryTypeDto
                    {
                        Id = d.DiscoveryType.Id,
                        Name = d.DiscoveryType.Name,
                        Description = d.DiscoveryType.Description
                    }
                })
                .FirstOrDefaultAsync();

            // Return the data
            var result = new RequestResult<DiscoveryDto> { Data = discovery };

            return result;
        }
    }
}
