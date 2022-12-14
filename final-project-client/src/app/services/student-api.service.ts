import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectFull, Student } from '../models/modelsInterfaces';

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
    return this.http.get<Student[]>(this.serverUrl + '/Student');
  }

  deleteStudent(id: number): Observable<Student> {
    return this.http.delete<Student>(this.serverUrl + `/Student/${id}`);
  }

  addStudent(student: Student): Observable<Student> {
    return this.http.post<Student>(this.serverUrl + '/Student', student);
  }

  getProject(id: number): Observable<ProjectFull> {
    return this.http.get<ProjectFull>(this.serverUrl + `/Project/${id}`);
  }
}
