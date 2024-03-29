import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectFull } from '../models/project-grade-models';
import {
  LecturerConstarintForDate,
  ScheduleDates,
} from '../models/schedule-models';
import { Lecturer } from '../models/users-models';

@Injectable({
  providedIn: 'root',
})
export class LecturerApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  getAllLecturer(): Observable<Lecturer[]> {
    return this.http.get<Lecturer[]>(
      this.serverUrl + '/Lecturer/ListLecturers'
    );
  }

  getLecturer(id: number): Observable<Lecturer> {
    return this.http.get<Lecturer>(`${this.serverUrl}/Lecturer/${id}`);
  }

  getAllProject(): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(this.serverUrl + '/Project');
  }

  getLecturerProjects(id: number): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(
      this.serverUrl + `/Project/GetAllProjectsOfLecturer/${id}`
    );
  }

  getScheduleDates(): Observable<ScheduleDates> {
    return this.http.get<ScheduleDates>(
      `${this.serverUrl}/Lecturer/ScheduleDates`
    );
  }

  PutLecturerConstraints(
    con: LecturerConstarintForDate
  ): Observable<LecturerConstarintForDate> {
    return this.http.put<LecturerConstarintForDate>(
      `${this.serverUrl}/Lecturer/PutLecturerConstraints`,
      con
    );
  }

  aproveProposal(id: number) {
    return this.http.post<boolean>(
      `${this.serverUrl}/Lecturer/ApproveProposal${id}`,
      null
    );
  }

  denyProposal(id: number) {
    return this.http.delete<boolean>(
      `${this.serverUrl}/Lecturer/DenyProposal/${id}`
    );
  }
}
