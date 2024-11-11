using PlanetaryExplorationLogs.API.Data.DTO.Discovery;
using PlanetaryExplorationLogs.API.Data.DTO.Planets;

namespace PlanetaryExplorationLogs.API.Data.DTO.Missions
{
    public class MissionListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime Date { get; set; }
        public int PlanetId { get; set; }
        public string Description { get; set; } = "";
        public PlanetDropdownDto? Planet { get; set; }
        public List<DiscoveryListItemDto> Discoveries { get; set; } = [];
    }
}
