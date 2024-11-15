﻿using Microsoft.AspNetCore.Mvc;
using PlanetaryExplorationLogs.API.Data.Context;
using PlanetaryExplorationLogs.API.Data.DTO.Discovery;
using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Data.Models;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateDiscoveryForMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.CreateMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.DeleteMission;
using PlanetaryExplorationLogs.API.Requests.Commands.Missions.UpdateMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetDiscoveriesForMission;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissionById;
using PlanetaryExplorationLogs.API.Requests.Queries.Missions.GetMissions;
using PlanetaryExplorationLogs.API.Utility.Patterns;

namespace PlanetaryExplorationLogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly PlanetExplorationDbContext _context;
        public MissionController(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        // GET: api/mission
        [HttpGet]
        public async Task<RequestResult<List<MissionListItemDto>>> GetMissions()
        {
            var query = new GetMissions_Query(_context);
            return await query.ExecuteAsync();
        }

        // GET: api/mission/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestResult<MissionDto>>> GetMission(int id)
        {
            var query = new GetMissionById_Query(_context, id);
            return await query.ExecuteAsync();
        }

        // POST: api/mission
        [HttpPost]
        public async Task<ActionResult<RequestResult<int>>> CreateMission([FromBody] CreateMissionDto createDto)
        {
            var mission = new Mission
            {
                Name = createDto.Name,
                Date = createDto.Date,
                PlanetId = createDto.PlanetId,
                Description = createDto.Description
            };

            var cmd = new CreateMission_Command(_context, mission);
            return await cmd.ExecuteAsync();
        }

        // PUT: api/mission/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<RequestResult<int>>> UpdateMission(int id, [FromBody] UpdateMissionDto updateDto)
        {
            var mission = new Mission
            {
                Id = id,
                Name = updateDto.Name,
                Date = updateDto.Date,
                PlanetId = updateDto.PlanetId,
                Description = updateDto.Description,
            };

            var cmd = new UpdateMission_Command(_context, id, mission);
            return await cmd.ExecuteAsync();
        }

        // DELETE: api/mission/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<RequestResult<int>>> DeleteMission(int id)
        {
            var cmd = new DeleteMission_Command(_context, id);
            return await cmd.ExecuteAsync();
        }

        // GET: api/mission/{missionId}/discovery
        [HttpGet("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<List<DiscoveryDto>>>> GetDiscoveriesForMission(int missionId)
        {
            var query = new GetDiscoveriesForMission_Query(_context, missionId);
            return await query.ExecuteAsync();
        }

        // POST: api/mission/{missionId}/discovery
        [HttpPost("{missionId}/discovery")]
        public async Task<ActionResult<RequestResult<int>>> CreateDiscoveryForMission(int missionId, [FromBody] CreateDiscoveryDto createDto)
        {
            var discovery = new Discovery
            {
                MissionId = missionId,
                Name = createDto.Name,
                Description = createDto.Description,
                Location = createDto.Location,
                DiscoveryTypeId = createDto.DiscoveryTypeId
            };

            var cmd = new CreateDiscoveryForMission_Command(_context, missionId, discovery);
            return await cmd.ExecuteAsync();
        }
    }
}
