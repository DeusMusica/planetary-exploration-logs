namespace PlanetaryExplorationLogs.API.Data.DTO.Planets
{
    public class PlanetListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Climate { get; set; } = "";
        public string Terrain { get; set; } = "";
        public string Population { get; set; } = "";
    }
}
