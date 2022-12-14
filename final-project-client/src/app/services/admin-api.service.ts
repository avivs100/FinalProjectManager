import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin, ProjectFull } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class AdminApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  getAdmin(id: number): Observable<Admin> {
    return this.http.get<Admin>(`${this.serverUrl}/Admin/${id}`);
  }

  getProjects(): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(
      `${this.serverUrl}/Project/GetProjects`
    );
  }
}
