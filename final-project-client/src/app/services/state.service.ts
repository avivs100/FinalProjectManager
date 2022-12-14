import { Injectable } from '@angular/core';
import { LecturerApiService } from './lecturer-api.service';
import {
  Admin,
  Lecturer,
  ProjectFull,
  Student,
} from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  public admin: Admin = {
    firstName: 'Naomi',
    id: 7,
    lastName: 'Onklus',
    password: '1',
    userType: 0,
  };

  public connectedUser: Student | Admin | Lecturer | null = this.admin;
  public projects: ProjectFull[] | null = null;
  public project: ProjectFull | null = null;
}
