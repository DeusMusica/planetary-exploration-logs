import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateDiscoveryDto } from '../../../models/discovery/create-discovery-dto.model';
import { DiscoveryService } from '../../../services/discovery.service';
import { MissionService } from '../../../services/mission.service';

@Component({
  selector: 'app-add-discovery',
  templateUrl: './add-discovery.component.html',
  styleUrl: './add-discovery.component.scss'
})
export class AddDiscoveryComponent implements OnInit{
  newDiscovery: CreateDiscoveryDto = {
    name: '',
    description: '',
    location: '',
    discoveryTypeId: 0,

  };
  missionId: number = 0;
  discoveryTypes: any[] = [];
  errorMessage: string = '';

  constructor(
    private discoveryService: DiscoveryService,
    private missionService: MissionService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // Get missionId from query parameters
    this.route.queryParams.subscribe(params => {
      this.missionId = +params['missionId'];
    });

    this.loadDiscoveryTypes(); // Load available discovery types
  }

  // Load discovery types for dropdown
  loadDiscoveryTypes(): void {
    // Assuming you have a method in your service to fetch discovery types
    this.discoveryService.getTypes().subscribe({
      next: (response) => {
        this.discoveryTypes = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading discovery types';
        console.error(error);
      }
    });
  }

  // Handle form submission
  addDiscovery(): void {
    this.missionService.addDiscoveryToMission(this.missionId, this.newDiscovery).subscribe({
      next: (response) => {
        this.router.navigate(['/mission']); // Navigate back to the mission list page on success
      },
      error: (error) => {
        this.errorMessage = 'Error adding discovery';
      }
    });
  }
}
