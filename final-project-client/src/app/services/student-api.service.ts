import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Project, Student } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class StudentApiService {
  readonly serverUrl = 'https://localhost:7114/api';

  constructor(private http: HttpClient) {}

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.serverUrl + `/Student/${id}`);
  }

  getAllStudents(): Observable<Student[]> {
    return this.http.get<any>(this.serverUrl + '/Student');
  }

  deleteStudent(id: number): Observable<Student> {
    return this.http.delete<any>(this.serverUrl + `/Student/${id}`);
  }

  addStudent(student: Student): Observable<Student> {
    return this.http.post<any>(this.serverUrl + '/Student', student);
  }

  getProject(id: number): Observable<Project> {
    return this.http.get<any>(this.serverUrl + `/Project/${id}`);
  }
}
