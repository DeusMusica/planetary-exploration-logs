import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../../../models/api-response.model';
import { UpdateMissionDto } from '../../../../models/mission/update-mission-dto.model';
import { Planet } from '../../../../models/planet/planet.model';
import { MissionService } from '../../../../services/mission.service';
import { PlanetService } from '../../../../services/planet.service';

@Component({
  selector: 'app-edit-mission',
  templateUrl: './edit-mission.component.html',
  styleUrls: ['./edit-mission.component.scss']
})
export class EditMissionComponent implements OnInit {
  missionId: number = 0;
  mission: UpdateMissionDto = {
    name: '',
    date: new Date(),
    planetId: 0,
    description: ''
  };
  planets: Planet[] = [];
  errorMessage: string = '';

  constructor(
    private missionService: MissionService,
    private planetService: PlanetService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.missionId = +this.route.snapshot.paramMap.get('missionId')!;
    this.loadMission();
    this.loadPlanets();
  }

  // Load the mission details
  loadMission(): void {
    this.missionService.getMission(this.missionId).subscribe({
      next: (response: ApiResponse<UpdateMissionDto>) => {
        this.mission = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading mission';
        console.error(error);
      }
    });
  }

  // Load planets for the dropdown
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

  // Handle form submission
  updateMission(): void {
    this.missionService.updateMission(this.missionId, this.mission).subscribe({
      next: () => {
        this.router.navigate(['/mission']);
      },
      error: (error) => {
        this.errorMessage = 'Error updating mission';
        console.error(error);
      }
    });
  }
}
