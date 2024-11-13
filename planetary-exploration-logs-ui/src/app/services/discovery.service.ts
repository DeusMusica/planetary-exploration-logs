import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { DiscoveryType } from '../models/discovery/discovery-type.model';
import { ApiResponse } from '../models/api-response.model';
import { CreateDiscoveryDto } from '../models/discovery/create-discovery-dto.model';
import { DiscoveryListItemDto } from '../models/discovery/discovery-list-item-dto.model';
import { UpdateDiscoveryDto } from '../models/discovery/update-discovery-dto.model';
import { Discovery } from '../models/discovery/discovery.model';

@Injectable({
  providedIn: 'root'
})
export class DiscoveryService {

  constructor(private apiService: ApiService) { }

// Get all discovery types
getTypes(): Observable<ApiResponse<DiscoveryListItemDto[]>> {
  return this.apiService.get<ApiResponse<DiscoveryListItemDto[]>>('/discovery/types');
}

// Get a single discovery by ID
getDiscovery(id: number): Observable<ApiResponse<Discovery>> {
  return this.apiService.get<ApiResponse<Discovery>>(`/discovery/${id}`);
}

// Create a new discovery
createDiscovery(data: CreateDiscoveryDto): Observable<ApiResponse<Discovery>> {
  return this.apiService.post<ApiResponse<Discovery>>('/discovery', data);
}

// Update an existing discovery
updateDiscovery(id: number, data: UpdateDiscoveryDto): Observable<ApiResponse<Discovery>> {
  return this.apiService.put<ApiResponse<Discovery>>(`/discovery/${id}`, data);
}

// Delete a discovery
deleteDiscovery(id: number): Observable<ApiResponse<void>> {
  return this.apiService.delete<ApiResponse<void>>(`/discovery/${id}`);
}
}
