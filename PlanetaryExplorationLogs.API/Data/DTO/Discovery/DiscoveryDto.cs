using PlanetaryExplorationLogs.API.Data.DTO.Missions;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Data.DTO.Discovery
{
    public class DiscoveryDto
    {
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int DiscoveryTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        // Simplified representations of related entities
        public MissionDto Mission { get; set; }
        public DiscoveryTypeDto DiscoveryType { get; set; }
    }
}
