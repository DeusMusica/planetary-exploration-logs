using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Utility.Patterns;
using PlanetaryExplorationLogs.API.Data.Context;
using static PlanetaryExplorationLogs.API.Utility.Patterns.CommandQuery;
using PlanetaryExplorationLogs.API.Data.Models;
using System.Net;
using PlanetaryExplorationLogs.API.Data.DTO;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;

namespace PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions
{
    public class GetMissions_Handler : HandlerBase<List<MissionListItemDto>>
	{
		public GetMissions_Handler(PlanetExplorationDbContext context)
			: base(context)
		{
		}

        public override async Task<RequestResult<List<MissionListItemDto>>> HandleAsync()
        {
            // First, let's check raw counts
            var missionCounts = await DbContext.Missions
                .Select(m => new
                {
                    MissionId = m.Id,
                    DiscoveryCount = m.Discoveries.Count
                })
                .ToListAsync();

            var missions = await DbContext.Missions
                .Include(m => m.Planet)
                .Include(m => m.Discoveries)
                    .ThenInclude(d => d.DiscoveryType)
                .OrderByDescending(t => t.Date)
                .Select(m => new MissionListItemDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Date = m.Date,
                    PlanetId = m.PlanetId,
                    Description = m.Description,
                    Planet = m.Planet != null ? new PlanetDropdownDto
                    {
                        Id = m.Planet.Id,
                        Name = m.Planet.Name
                    } : null,
                    Discoveries = m.Discoveries.Select(d => new DiscoveryListItemDto
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        Location = d.Location,
                        DiscoveryTypeName = d.DiscoveryType.Name
                    }).ToList()
                })
                .ToListAsync();

            // Add debug info to the message
            var debugInfo = string.Join(", ", missionCounts.Select(m => $"Mission {m.MissionId}: {m.DiscoveryCount} discoveries"));

            return new RequestResult<List<MissionListItemDto>>
            {
                Data = missions,
                StatusCode = HttpStatusCode.OK,
                Message = $"Missions retrieved successfully. Debug info: {debugInfo}"
            };
        }
    }
}
