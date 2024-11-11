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

            if (!await _context.DiscoveryTypes.AnyAsync())
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
                   // Terra Nova Geological Survey discoveries
                   new Discovery
                   {
                       Id = 1,
                       MissionId = 1,
                       DiscoveryTypeId = 1, // Geological
                       Name = "Rich Iron Deposit",
                       Description = "A massive deposit of iron ore discovered beneath a tectonic fault line.",
                       Location = "Mount Eris, Terra Nova"
                   },
                   new Discovery
                   {
                       Id = 2,
                       MissionId = 1,
                       DiscoveryTypeId = 1, // Geological
                       Name = "Active Volcanic Vent",
                       Description = "Discovery of an active geothermal vent system with unique mineral formations.",
                       Location = "Vulcan Valley, Terra Nova"
                   },
                   new Discovery
                   {
                       Id = 3,
                       MissionId = 1,
                       DiscoveryTypeId = 3, // Technological
                       Name = "Ancient Mining Site",
                       Description = "Evidence of previous mining operations, possibly from an unknown civilization.",
                       Location = "Deep Canyon Delta, Terra Nova"
                   },

                   // Xenon Prime Atmospheric Expedition discoveries
                   new Discovery
                   {
                       Id = 4,
                       MissionId = 2,
                       DiscoveryTypeId = 4, // Atmospheric
                       Name = "Supercell Storm Formation",
                       Description = "Observed a record-breaking supercell storm, with wind speeds exceeding 400 km/h.",
                       Location = "Southern Hemisphere, Xenon Prime"
                   },
                   new Discovery
                   {
                       Id = 5,
                       MissionId = 2,
                       DiscoveryTypeId = 4, // Atmospheric
                       Name = "Metallic Cloud Layer",
                       Description = "Identified a unique layer of metallic compounds in the upper atmosphere.",
                       Location = "Equatorial Band, Xenon Prime"
                   },
                   new Discovery
                   {
                       Id = 6,
                       MissionId = 2,
                       DiscoveryTypeId = 2, // Biological
                       Name = "Atmospheric Microorganisms",
                       Description = "Detection of microscopic life forms surviving in the upper atmosphere.",
                       Location = "Upper Troposphere, Xenon Prime"
                   },

                   // Glaciera Ice Core Drilling discoveries
                   new Discovery
                   {
                       Id = 7,
                       MissionId = 3,
                       DiscoveryTypeId = 2, // Biological
                       Name = "Ancient Microbial Life",
                       Description = "Discovered well-preserved microorganisms in ice cores, dating back over 100,000 years.",
                       Location = "North Ice Cap, Glaciera"
                   },
                   new Discovery
                   {
                       Id = 8,
                       MissionId = 3,
                       DiscoveryTypeId = 1, // Geological
                       Name = "Subglacial Lake Network",
                       Description = "Mapped an extensive network of interconnected liquid water lakes beneath the ice.",
                       Location = "Central Ice Sheet, Glaciera"
                   },
                   new Discovery
                   {
                       Id = 9,
                       MissionId = 3,
                       DiscoveryTypeId = 3, // Technological
                       Name = "Preserved Artifacts",
                       Description = "Collection of preserved tools and devices found in deep ice layers.",
                       Location = "Eastern Glacier Zone, Glaciera"
                   },

                   // Dwarfia Desert Exploration discoveries
                   new Discovery
                   {
                       Id = 10,
                       MissionId = 4,
                       DiscoveryTypeId = 1, // Geological
                       Name = "Silicon Dunes",
                       Description = "Vast dunes of silicon-based sand, possibly formed by ancient volcanic activity.",
                       Location = "Great Dwarfian Desert, Dwarfia"
                   },
                   new Discovery
                   {
                       Id = 11,
                       MissionId = 4,
                       DiscoveryTypeId = 4, // Atmospheric
                       Name = "Dust Devil Phenomena",
                       Description = "Unique patterns of electrified dust devils carrying rare mineral particles.",
                       Location = "Central Desert Plain, Dwarfia"
                   },

                   // Terra Nova Biological Census discoveries
                   new Discovery
                   {
                       Id = 12,
                       MissionId = 5,
                       DiscoveryTypeId = 2, // Biological
                       Name = "New Species of Aquatic Flora",
                       Description = "Identified a new species of bioluminescent algae thriving in the deep ocean trenches.",
                       Location = "Trench of Light, Terra Nova"
                   },
                   new Discovery
                   {
                       Id = 13,
                       MissionId = 5,
                       DiscoveryTypeId = 2, // Biological
                       Name = "Mountain Dwelling Creatures",
                       Description = "Discovery of highly adapted vertebrates living in high-altitude mountain caves.",
                       Location = "Peak Range, Terra Nova"
                   },
                   new Discovery
                   {
                       Id = 14,
                       MissionId = 5,
                       DiscoveryTypeId = 3, // Technological
                       Name = "Bioengineered Plant Species",
                       Description = "Evidence of artificially modified plant life, suggesting previous colonization attempts.",
                       Location = "Coastal Research Zone, Terra Nova"
                   }
               );
                await _context.SaveChangesAsync();
            }
        }
    }
}
