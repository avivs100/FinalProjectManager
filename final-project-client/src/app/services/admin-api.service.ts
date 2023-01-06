import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {
  ProjectFull,
  ProjectProposalDetailsWithStatus,
} from '../models/project-grade-models';
import { Admin, Student, Lecturer, premission } from '../models/users-models';

@Injectable({
  providedIn: 'root',
})
export class AdminApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  getAdmin(id: number): Observable<Admin> {
    return this.http.get<Admin>(`${this.serverUrl}/Admin/${id}`);
  }

  getAdmins(): Observable<Admin[]> {
    return this.http.get<Admin[]>(`${this.serverUrl}/Admin`);
  }

  getStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(`${this.serverUrl}/Student/students`);
  }

  getProjects(): Observable<ProjectFull[]> {
    return this.http.get<ProjectFull[]>(
      `${this.serverUrl}/Project/GetProjects`
    );
  }

  getProjectById(id: number): Observable<ProjectFull> {
    return this.http.get<ProjectFull>(`${this.serverUrl}/Project/${id}`);
  }

  deleteProjectById(id: number): Observable<ProjectFull> {
    return this.http.delete<ProjectFull>(`${this.serverUrl}/Project/${id}`);
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.serverUrl + `/Student/${id}`);
  }

  deleteStudent(id: number): Observable<Student> {
    return this.http.delete<Student>(this.serverUrl + `/Student/${id}`);
  }

  getAllLecturer(): Observable<Lecturer[]> {
    return this.http.get<Lecturer[]>(
      this.serverUrl + '/Lecturer/ListLecturers'
    );
  }

  getLecturer(id: number): Observable<Lecturer> {
    return this.http.get<Lecturer>(`${this.serverUrl}/Lecturer/${id}`);
  }

  getScheduleDates(): Observable<any> {
    return this.http.get<any>(`${this.serverUrl}/Lecturer/ScheduleDates`);
  }

  getPremissions(): Observable<premission[]> {
    return this.http.get<premission[]>(`${this.serverUrl}/Admin/premissions`);
  }

  deleteLecturerPremission(id: number): Observable<boolean> {
    return this.http.delete<boolean>(
      `${this.serverUrl}/Admin/DeletePremission/${id}`
    );
  }

  aproveLecturerPremission(id: number): Observable<boolean> {
    return this.http.post<boolean>(
      `${this.serverUrl}/Admin/ApproveLecturer/${id}`,
      null
    );
  }

  putScheduleDates(dates: any) {
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/PutScheduleDates`,
      dates
    );
  }

  aproveProposal(id: number, code: string) {
    return this.http.post<boolean>(
      `${this.serverUrl}/Admin/ApproveProposal/${id}/${code}`,
      null
    );
  }

  getProposalsAfterAprove(): Observable<ProjectProposalDetailsWithStatus[]> {
    return this.http.get<ProjectProposalDetailsWithStatus[]>(
      `${this.serverUrl}/Admin/GetAllProposalsAfterLecturerApprove`
    );
  }
}
