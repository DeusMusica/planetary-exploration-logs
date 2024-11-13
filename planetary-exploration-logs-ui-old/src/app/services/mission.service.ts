import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MissionService {
  constructor(private apiService: ApiService) {}

  getMissions(): Observable<any> {
    return this.apiService.get('/Mission');
  }

  createMission(data: any): Observable<any> {
    return this.apiService.post('/Mission', data);
  }

  getMissionById(id: string): Observable<any> {
    return this.apiService.get(`/Mission/${id}`);
  }

  updateMission(id: string, data: any): Observable<any> {
    return this.apiService.put(`/Mission/${id}`, data);
  }

  deleteMission(id: string): Observable<any> {
    return this.apiService.delete(`/Mission/${id}`);
  }

  getMissionDiscovery(missionId: string): Observable<any> {
    return this.apiService.get(`/Mission/${missionId}/discovery`);
  }

  addMissionDiscovery(missionId: string, data: any): Observable<any> {
    return this.apiService.post(`/Mission/${missionId}/discovery`, data);
  }
}
