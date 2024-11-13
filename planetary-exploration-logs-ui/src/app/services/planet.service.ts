import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ApiResponse } from '../models/api-response.model';
import { Planet } from '../models/planet/planet.model';

@Injectable({
  providedIn: 'root'
})
export class PlanetService {
  constructor(private apiService: ApiService) {}

  getDropdown(): Observable<any> {
    return this.apiService.get('/Planet/dropdown');
  }

  getAllPlanets(): Observable<ApiResponse<Planet[]>> {
    return this.apiService.get<ApiResponse<Planet[]>>('/planet');
  }

  createPlanet(data: any): Observable<any> {
    return this.apiService.post('/Planet', data);
  }

  updatePlanet(data: any): Observable<any> {
    return this.apiService.put('/Planet', data);
  }

  deletePlanet(id: string): Observable<any> {
    return this.apiService.delete(`/Planet/${id}`);
  }
}
