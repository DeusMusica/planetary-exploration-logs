import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../../models/api-response.model';
import { UpdateDiscoveryDto } from '../../../models/discovery/update-discovery-dto.model';
import { DiscoveryService } from '../../../services/discovery.service';

@Component({
  selector: 'app-edit-discovery',
  templateUrl: './edit-discovery.component.html',
  styleUrl: './edit-discovery.component.scss'
})
export class EditDiscoveryComponent implements OnInit {
  discoveryId: number = 0;
  discovery: UpdateDiscoveryDto = {
    name: '',
    description: '',
    location: '',
    missionId: 0,
    discoveryTypeId: 0
  };
  discoveryTypes: any[] = [];
  errorMessage: string = '';

  constructor(
    private discoveryService: DiscoveryService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.discoveryId = +this.route.snapshot.paramMap.get('discoveryId')!;
    this.loadDiscovery();
    this.loadDiscoveryTypes();
  }

  // Load the discovery details
  loadDiscovery(): void {
    this.discoveryService.getDiscovery(this.discoveryId).subscribe({
      next: (response: ApiResponse<UpdateDiscoveryDto>) => {
        this.discovery = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading discovery';
        console.error(error);
      }
    });
  }

  // Load discovery types for the dropdown
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
  updateDiscovery(): void {
    this.discoveryService.updateDiscovery(this.discoveryId, this.discovery).subscribe({
      next: () => {
        this.router.navigate(['/mission']); // Navigate back to the mission list page on success
      },
      error: (error) => {
        this.errorMessage = 'Error updating discovery';
        console.error(error);
      }
    });
  }
}
