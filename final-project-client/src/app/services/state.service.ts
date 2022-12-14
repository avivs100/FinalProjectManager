import { Injectable } from '@angular/core';
import { LecturerApiService } from './lecturer-api.service';
import { Admin, Lecturer, Project, Student } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  public connectedUser: Student | Admin | Lecturer | null = null;
  public projects: Project[] | null = null;
  public project: Project | null = null;
}
