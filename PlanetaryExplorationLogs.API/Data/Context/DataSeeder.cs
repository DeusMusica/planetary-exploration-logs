using Microsoft.EntityFrameworkCore;
using PlanetaryExplorationLogs.API.Data.Models;

namespace PlanetaryExplorationLogs.API.Data.Context
{
    public class DataSeeder
    {
        private readonly PlanetExplorationDbContext _context;
        public DataSeeder(PlanetExplorationDbContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (!await _context.Planets.AnyAsync())
            {
                await _context.Planets.AddRangeAsync(
                    new Planet
                    {
                        Id = 1,
                        Name = "Terra Nova",
                        Type = "Terrestrial",
                        Climate = "Temperate",
                        Terrain = "Mountains and Oceans",
                        Population = "Sparse Colonies"
                    },
                    new Planet
                    {
                        Id = 2,
                        Name = "Xenon Prime",
                        Type = "Gas Giant",
                        Climate = "Extreme Storms",
                        Terrain = "Gaseous Layers",
                        Population = "Uninhabited"
                    },
                    new Planet
                    {
                        Id = 3,
                        Name = "Glaciera",
                        Type = "Ice Giant",
                        Climate = "Frozen",
                        Terrain = "Ice Plains and Subsurface Oceans",
                        Population = "Uninhabited"
                    },
                    new Planet
                    {
                        Id = 4,
                        Name = "Dwarfia",
                        Type = "Dwarf",
                        Climate = "Arid",
                        Terrain = "Deserts",
                        Population = "Uninhabited"
                    }
                );
                await _context.SaveChangesAsync();
            }

            if(!await _context.DiscoveryTypes.AnyAsync())
            {
                await _context.DiscoveryTypes.AddRangeAsync(
                    new DiscoveryType
                    {
                        Id = 1,
                        Name = "Geological",
                        Description = "Discoveries related to the planet's geology, such as mineral deposits and tectonic activity."
                    },
                    new DiscoveryType
                    {
                        Id = 2,
                        Name = "Biological",
                        Description = "Discoveries pertaining to life forms, ecosystems, and biological phenomena."
                    },
                    new DiscoveryType
                    {
                        Id = 3,
                        Name = "Technological",
                        Description = "Findings related to advanced technologies, alien artifacts, or unexplained mechanisms."
                    },
                    new DiscoveryType
                    {
                        Id = 4,
                        Name = "Atmospheric",
                        Description = "Discoveries involving atmospheric compositions, weather patterns, and climate anomalies."
                    }
                );
                await _context.SaveChangesAsync();
            }

            if (!await _context.Missions.AnyAsync())
            {
                await _context.Missions.AddRangeAsync(
                    new Mission
                    {
                        Id = 1,
                        Name = "Terra Nova Geological Survey",
                        Date = new DateTime(2124, 5, 10),
                        PlanetId = 1, // Terra Nova
                        Description = "A detailed geological survey to map mineral deposits and tectonic faults on Terra Nova."
                    },
                    new Mission
                    {
                        Id = 2,
                        Name = "Xenon Prime Atmospheric Expedition",
                        Date = new DateTime(2125, 3, 15),
                        PlanetId = 2, // Xenon Prime
                        Description = "An atmospheric study of extreme storms and gas compositions on Xenon Prime."
                    },
                    new Mission
                    {
                        Id = 3,
                        Name = "Glaciera Ice Core Drilling",
                        Date = new DateTime(2126, 1, 20),
                        PlanetId = 3, // Glaciera
                        Description = "A mission to drill ice cores on Glaciera to study ancient subsurface ocean ecosystems."
                    },
                    new Mission
                    {
                        Id = 4,
                        Name = "Dwarfia Desert Exploration",
                        Date = new DateTime(2126, 9, 12),
                        PlanetId = 4, // Dwarfia
                        Description = "An expedition to explore the vast deserts of Dwarfia and search for signs of ancient water sources."
                    },
                    new Mission
                    {
                        Id = 5,
                        Name = "Terra Nova Biological Census",
                        Date = new DateTime(2127, 4, 18),
                        PlanetId = 1, // Terra Nova
                        Description = "A biological census to catalog flora and fauna in Terra Nova's mountain and ocean regions."
                    }
                );
                await _context.SaveChangesAsync();
            }

            if (!await _context.Discoveries.AnyAsync())
            {
                await _context.Discoveries.AddRangeAsync(
                    new Discovery
                    {
                        Id = 1,
                        MissionId = 1, // Terra Nova Geological Survey
                        DiscoveryTypeId = 1, // Geological
                        Name = "Rich Iron Deposit",
                        Description = "A massive deposit of iron ore discovered beneath a tectonic fault line.",
                        Location = "Mount Eris, Terra Nova"
                    },
                    new Discovery
                    {
                        Id = 2,
                        MissionId = 2, // Xenon Prime Atmospheric Expedition
                        DiscoveryTypeId = 4, // Atmospheric
                        Name = "Supercell Storm Formation",
                        Description = "Observed a record-breaking supercell storm, with wind speeds exceeding 400 km/h.",
                        Location = "Southern Hemisphere, Xenon Prime"
                    },
                    new Discovery
                    {
                        Id = 3,
                        MissionId = 3, // Glaciera Ice Core Drilling
                        DiscoveryTypeId = 2, // Biological
                        Name = "Ancient Microbial Life",
                        Description = "Discovered well-preserved microorganisms in ice cores, dating back over 100,000 years.",
                        Location = "North Ice Cap, Glaciera"
                    },
                    new Discovery
                    {
                        Id = 4,
                        MissionId = 4, // Dwarfia Desert Exploration
                        DiscoveryTypeId = 1, // Geological
                        Name = "Silicon Dunes",
                        Description = "Vast dunes of silicon-based sand, possibly formed by ancient volcanic activity.",
                        Location = "Great Dwarfian Desert, Dwarfia"
                    },
                    new Discovery
                    {
                        Id = 5,
                        MissionId = 5, // Terra Nova Biological Census
                        DiscoveryTypeId = 2, // Biological
                        Name = "New Species of Aquatic Flora",
                        Description = "Identified a new species of bioluminescent algae thriving in the deep ocean trenches.",
                        Location = "Trench of Light, Terra Nova"
                    }
                );
                await _context.SaveChangesAsync();
            }
        }
    }
}
