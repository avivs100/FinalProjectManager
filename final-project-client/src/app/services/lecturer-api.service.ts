import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lecturer, ProjectFull } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class LecturerApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  getAllLecturer(): Observable<Lecturer[]> {
    return this.http.get<Lecturer[]>(this.serverUrl + '/Lecturer');
  }

  getLecturer(id: number): Observable<Lecturer> {
    return this.http.get<Lecturer>(`${this.serverUrl}/Lecturer/${id}`);
  }

  getAllProject(): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(this.serverUrl + '/Project');
  }

  getLecturerProjects(id: string): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(
      this.serverUrl + `/Project/GetAllProjectsOfLecturer/${id}`
    );
  }
}
