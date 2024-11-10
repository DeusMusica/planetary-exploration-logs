namespace PlanetaryExplorationLogs.API.Data.DTO
{
    public class MissionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int PlanetId { get; set; }
        public string Description { get; set; }

        // Simplified representation of the Planet
        public string PlanetName { get; set; }
    }
}
