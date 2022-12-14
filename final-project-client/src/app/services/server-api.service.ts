import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lecturer, Project, Student } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class ServerApiService {
  readonly serverUrl = 'https://localhost:44337/api';

  constructor(private http: HttpClient) {}
}
