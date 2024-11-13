import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiscoveryService {

  constructor(private apiService: ApiService) { }

  getTypes(): Observable<any> {
    return this.apiService.get('/Discovery/types');
  }
  
  getDiscovery(id: string): Observable<any> {
    return this.apiService.get(`/Discovery/${id}`);
  }

  updateDiscovery(id: string, data: any): Observable<any> {
    return this.apiService.put(`/Discovery/${id}`, data);
  }

  deleteDiscovery(id: string): Observable<any> {
    return this.apiService.delete(`/Discovery/${id}`);
  }
}
