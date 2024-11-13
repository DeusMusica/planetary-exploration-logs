import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { ApiResponse } from '../models/api-response.model';
import { CreateDiscoveryDto } from '../models/discovery/create-discovery-dto.model';
import { CreateMissionDto } from '../models/mission/create-mission-dto.model';
import { MissionDto } from '../models/mission/mission-dto.model';
import { UpdateMissionDto } from '../models/mission/update-mission-dto.model';
import { MissionListItemDto } from '../models/mission/mission-list-item-dto.model';
import { Discovery } from '../models/discovery/discovery.model';

@Injectable({
  providedIn: 'root'
})
export class MissionService {
  constructor(private apiService: ApiService) {}

  // Get all missions
  getMissions(): Observable<ApiResponse<MissionListItemDto[]>> {
    return this.apiService.get<ApiResponse<MissionListItemDto[]>>('/mission');
  }

  // Get a single mission by ID
  getMission(id: number): Observable<ApiResponse<MissionDto>> {
    return this.apiService.get<ApiResponse<MissionDto>>(`/mission/${id}`);
  }

  // Create a new mission
  createMission(data: CreateMissionDto): Observable<ApiResponse<MissionDto>> {
    return this.apiService.post<ApiResponse<MissionDto>>('/mission', data);
  }

  // Update an existing mission
  updateMission(id: number, data: UpdateMissionDto): Observable<ApiResponse<MissionDto>> {
    return this.apiService.put<ApiResponse<MissionDto>>(`/mission/${id}`, data);
  }

  // Delete a mission
  deleteMission(id: number): Observable<ApiResponse<void>> {
    return this.apiService.delete<ApiResponse<void>>(`/mission/${id}`);
  }

  // Get discoveries for a specific mission
  getMissionDiscoveries(missionId: number): Observable<ApiResponse<Discovery[]>> {
    return this.apiService.get<ApiResponse<Discovery[]>>(`/mission/${missionId}/discovery`);
  }

  // Add a discovery to a mission
  addDiscoveryToMission(missionId: number, data: CreateDiscoveryDto): Observable<ApiResponse<Discovery>> {
    return this.apiService.post<ApiResponse<Discovery>>(`/mission/${missionId}/discovery`, data);
  }
}