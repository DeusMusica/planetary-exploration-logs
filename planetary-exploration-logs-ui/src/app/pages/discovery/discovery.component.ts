import { Component, OnInit } from '@angular/core';
import { DiscoveryService } from '../../services/discovery.service';
import { DiscoveryType } from '../../models/discovery/discovery-type.model';
import { CreateDiscoveryDto } from '../../models/discovery/create-discovery-dto.model';
import { DiscoveryListItemDto } from '../../models/discovery/discovery-list-item-dto.model';
import { UpdateDiscoveryDto } from '../../models/discovery/update-discovery-dto.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Discovery } from '../../models/discovery/discovery.model';

@Component({
  selector: 'app-discovery',
  templateUrl: './discovery.component.html',
  styleUrl: './discovery.component.scss'
})
export class DiscoveryComponent{
  discoveries: DiscoveryListItemDto[] = [];
  discoveryTypes: DiscoveryType[] = [];
  selectedDiscovery: Discovery | null = null;
  errorMessage: string = '';

  constructor(
    private discoveryService: DiscoveryService,
    private modalService: NgbModal
  ) {}

  // Load all discoveries
  loadDiscoveries(): void {
    this.discoveryService.getTypes().subscribe({
      next: (response) => {
        this.discoveries = response.data;
      },
      error: (error) => {
        this.errorMessage = 'Error loading discoveries';
        console.error(error);
      }
    });
  }

  // Create a new discovery
  createDiscovery(newDiscovery: CreateDiscoveryDto): void {
    this.discoveryService.createDiscovery(newDiscovery).subscribe({
      next: () => {
        this.loadDiscoveries(); // Reload the list
        this.modalService.dismissAll(); // Close the modal
      },
      error: (error) => {
        this.errorMessage = 'Error creating discovery';
        console.error(error);
      }
    });
  }

  // Update an existing discovery
  updateDiscovery(updatedDiscovery: UpdateDiscoveryDto): void {
    if (this.selectedDiscovery) {
      this.discoveryService.updateDiscovery(this.selectedDiscovery.id, updatedDiscovery).subscribe({
        next: () => {
          this.loadDiscoveries(); // Reload the list
          this.modalService.dismissAll(); // Close the modal
        },
        error: (error) => {
          this.errorMessage = 'Error updating discovery';
          console.error(error);
        }
      });
    }
  }

  // Delete a discovery
  deleteDiscovery(discoveryId: number): void {
    if (confirm('Are you sure you want to delete this discovery?')) {
      this.discoveryService.deleteDiscovery(discoveryId).subscribe({
        next: () => {
          this.loadDiscoveries(); // Reload the list
        },
        error: (error) => {
          this.errorMessage = 'Error deleting discovery';
          console.error(error);
        }
      });
    }
  }
}
