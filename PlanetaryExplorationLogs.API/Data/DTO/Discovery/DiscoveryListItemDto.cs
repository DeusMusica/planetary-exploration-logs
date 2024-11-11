namespace PlanetaryExplorationLogs.API.Data.DTO.Discovery
{
    public class DiscoveryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public string DiscoveryTypeName { get; set; } = "";
    }
}
