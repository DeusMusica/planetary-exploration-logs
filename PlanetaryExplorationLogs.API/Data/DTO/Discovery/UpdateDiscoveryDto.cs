namespace PlanetaryExplorationLogs.API.Data.DTO.Discovery
{
    public class UpdateDiscoveryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public int? MissionId { get; set; }
        public int? DiscoveryTypeId { get; set; }
    }
}
