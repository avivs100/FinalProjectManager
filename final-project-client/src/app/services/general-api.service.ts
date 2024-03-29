import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectProposalDetailsWithStatus } from '../models/project-grade-models';
import { ScheduleDates } from '../models/schedule-models';
import { Admin, Lecturer, Student } from '../models/users-models';

import { RegisterFormData } from '../pages/login/login-page/register-dialog/register-form/register-form.component';

@Injectable({
  providedIn: 'root',
})
export class GeneralApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  public login(id: number, pass: string): Observable<number> {
    console.log('generalApiLoginFunction');
    return this.http.get<number>(this.serverUrl + `/LogIn/${id}/${pass}`);
  }
  getAdmins(): Observable<Admin[]> {
    return this.http.get<Admin[]>(`${this.serverUrl}/Admin`);
  }

  getAdmin(id: number): Observable<Admin> {
    return this.http.get<Admin>(`${this.serverUrl}/Admin/${id}`);
  }

  getLecturer(id: number): Observable<Lecturer> {
    return this.http.get<Lecturer>(`${this.serverUrl}/Lecturer/${id}`);
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.serverUrl + `/Student/${id}`);
  }

  register(data: RegisterFormData): Observable<boolean> {
    return this.http.put<boolean>(`${this.serverUrl}/Register/Register`, data);
  }

  getScheduleDate(): Observable<ScheduleDates> {
    return this.http.get<ScheduleDates>(
      `${this.serverUrl}/Project/GetScheduleDates`
    );
  }

  getProposals(): Observable<ProjectProposalDetailsWithStatus[]> {
    return this.http.get<ProjectProposalDetailsWithStatus[]>(
      this.serverUrl + `/Admin/GetProposals`
    );
  }
}
