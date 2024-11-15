import { Component, OnInit } from '@angular/core';
import { ApiResponse } from '../../models/api-response.model';
import { MissionListItemDto } from '../../models/mission/mission-list-item-dto.model';
import { MissionService } from '../../services/mission.service';
import { Router } from '@angular/router';
import { Planet } from '../../models/planet/planet.model';
import { PlanetService } from '../../services/planet.service';
import { Observable } from 'rxjs';
import { ApiService } from '../../services/api.service';
import { DiscoveryService } from '../../services/discovery.service';

@Component({
  selector: 'app-mission',
  templateUrl: './mission.component.html',
  styleUrl: './mission.component.scss'
})
export class MissionComponent implements OnInit {
  missions: MissionListItemDto[] = [];
  planets: Planet[] = []
  selectedMissionId: number | null = null;
  selectedPlanet: Planet | null = null ;
  errorMessage: string = '';

  constructor(
    private missionService: MissionService,
    private planetService: PlanetService,
    private discoveryService: DiscoveryService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadMissions();
    this.loadPlanets();
  }

  // Load all missions
  loadMissions(): void {
    this.missionService.getMissions().subscribe({
      next: (response: ApiResponse<MissionListItemDto[]>) => {
        this.missions = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading missions';
        console.error(error);
      }
    });
  }

   // Load all planets
   loadPlanets(): void {
    this.planetService.getAllPlanets().subscribe({
      next: (response: ApiResponse<Planet[]>) => {
        this.planets = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading planets';
        console.error(error);
      }
    });
  }

toggleMissionDetails(missionId: number): void {
  // Toggle the selected mission ID; close if the same mission is clicked
  this.selectedMissionId = this.selectedMissionId === missionId ? null : missionId;

  // If a mission is selected, find and set the corresponding planet
  if (this.selectedMissionId !== null) {
    const selectedMission = this.missions.find(m => m.id === this.selectedMissionId);
    this.selectedPlanet = this.planets.find(p => p.id === selectedMission?.planetId) || null;
  } else {
    this.selectedPlanet = null;
  }
}

  // Navigate to the create mission page
  addNewMission(): void {
    this.router.navigate(['/mission/create']);
  }

  // Updated method to add discoveries
  addDiscoveries(mission: MissionListItemDto): void {
    // Navigate to the Add Discovery page, passing the missionId
    this.router.navigate(['/discovery/add'], { queryParams: { missionId: mission.id } });
  }

  // Method to edit discoveries
  editDiscoveries(discoveryId: number): void {
    // Navigate to the edit discovery page, passing the discovery ID as a route parameter
    this.router.navigate(['/discovery/edit', discoveryId]);
  }

  editMission(missionId: number): void {
    // Navigate to the edit mission page, passing the mission ID as a route parameter
    this.router.navigate(['/mission/edit', missionId]);
  }

  deleteDiscovery(discoveryId: number): void {
    if (confirm('Are you sure you want to delete this discovery?')) {
      this.discoveryService.deleteDiscovery(discoveryId).subscribe({
        next: () => {
          const selectedMission = this.missions.find(m => m.id === this.selectedMissionId);
          if (selectedMission) {
            selectedMission.discoveries = selectedMission.discoveries.filter(d => d.id !== discoveryId);
          }
        }
      })
    }
  }

  // Method to delete the mission
  deleteMission(missionId: number): void {
    if (confirm('Are you sure you want to delete this mission?')) {
      this.missionService.deleteMission(missionId).subscribe({
        next: () => {
          this.loadMissions(); // Reload missions after deletion
        },
        error: (error) => {
          this.errorMessage = 'Error deleting mission';
          console.error(error);
        }
      });
    }
  }
}
