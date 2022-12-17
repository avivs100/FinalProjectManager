import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin, Lecturer, Student, UserType } from '../models/modelsInterfaces';
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

  getAdmin(id: number): Observable<Admin> {
    return this.http.get<Admin>(`${this.serverUrl}/Admin/${id}`);
  }

  getLecturer(id: number): Observable<Lecturer> {
    return this.http.get<Lecturer>(`${this.serverUrl}/Lecturer/${id}`);
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.serverUrl + `/Student/${id}`);
  }

  getScheduleDates(): Observable<any> {
    return this.http.get<any>(`${this.serverUrl}/Lecturer/ScheduleDates`);
  }

  register(data: RegisterFormData): Observable<boolean> {
    return this.http.put<boolean>(`${this.serverUrl}/Register/Register`, data);
  }
}
