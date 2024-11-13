import { Component, OnInit } from '@angular/core';
import { CreateMissionDto } from '../../../models/mission/create-mission-dto.model';
import { Planet } from '../../../models/planet/planet.model';
import { MissionService } from '../../../services/mission.service';
import { PlanetService } from '../../../services/planet.service';
import { Router } from '@angular/router';
import { CreateDiscoveryDto } from '../../../models/discovery/create-discovery-dto.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PlanetDropdownDto } from '../../../models/planet/planet-dropdown-dto.model';
import { PlanetFormDto } from '../../../models/planet/planet-form-dto.model';
import { ApiResponse } from '../../../models/api-response.model';
import { DiscoveryService } from '../../../services/discovery.service';
import { DiscoveryType } from '../../../models/discovery/discovery-type.model';

@Component({
  selector: 'app-create-mission',
  templateUrl: './create-mission.component.html',
  styleUrl: './create-mission.component.scss'
})
export class CreateMissionComponent implements OnInit{
  newMission: CreateMissionDto = {
    name: '',
    date: new Date(),
    planetId: 0,
    description: ''
  };
  planets: PlanetDropdownDto[] = [];
  discoveryTypes: DiscoveryType[] = [];
  errorMessage: string = '';
  newDiscovery: CreateDiscoveryDto = {
    name: '',
    description: '',
    location: '',
    discoveryTypeId: 0
  };
  discoveries: CreateDiscoveryDto[] =[];

  newPlanet: PlanetFormDto = {
    name: '',
    type: '',
    climate: '',
    terrain: '',
    population: ''
  }

  constructor(
    private discoveryService: DiscoveryService,
    private missionService: MissionService,
    private planetService: PlanetService,
    private router: Router,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.loadPlanets();
  }

  // Load all planets for the dropdown
  loadPlanets(): void {
    this.planetService.getAllPlanets().subscribe({
      next: (response) => {
        this.planets = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading planets';
        console.error(error);
      }
    });
  }

  // Save the mission
  createMission(): void {
    if (this.newMission.planetId === 0) {
      this.errorMessage = 'Please select a planet';
      return;
    }

    this.missionService.createMission(this.newMission).subscribe({
      next: (response) => {
        const missionId = response.data.id;
        // Add each discovery to the mission
        this.discoveries.forEach(discovery => {
          this.missionService.addDiscoveryToMission(missionId, discovery).subscribe({
            error: (error) => {
              console.error('Error adding discovery:', error);
            }
          });
        });
        this.router.navigate(['/mission']);
      },
      error: (error) => {
        this.errorMessage = 'Error creating mission';
        console.error(error);
      }
    });
  }

  // Open a modal to add a new planet
  openAddPlanetModal(content: any): void {
    this.modalService.open(content, { size: 'lg' });
  }

  // Handle adding a new planet
  addPlanet(): void {
    if (!this.newPlanet.name || !this.newPlanet.type) {
      this.errorMessage = 'Planet name and type are required';
      return;
    }

    this.planetService.createPlanet(this.newPlanet).subscribe({
      next: (response: ApiResponse<PlanetDropdownDto>) => {
        // Close the modal on success
        this.modalService.dismissAll();
        // Reload the planets to include the newly added one
        this.loadPlanets();
        // Optionally, set the newly added planet as the selected planet
        this.newMission.planetId = response.data.id;
      },
      error: (error) => {
        this.errorMessage = 'Error adding new planet';
        console.error(error);
      }
    });
  }
}
