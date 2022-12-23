import { ScheduleDates } from './../models/schedule-models';
import { Injectable } from '@angular/core';
import { ProjectFull } from '../models/project-grade-models';
import { Admin, Lecturer, Student } from '../models/users-models';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  public admin: Admin = {
    firstName: 'Naomi',
    email: 'test@gmail.com',
    id: 7,
    lastName: 'Onklus',
    password: '1',
    userType: 0,
  };

  public lecturer: Lecturer = {
    id: 4,
    userType: 2,
    firstName: 'Eres',
    lastName: 'Erez',
    password: '1',
    email: 'default@gmaol.com',
    constraints: [],
    isActive: true,
  };

  public student: Student = {
    id: 2,
    userType: 1,
    partnerId: 0,
    password: '1',
    firstName: 'Sagi',
    lastName: 'Fishman',
    email: 'default@gmaol.com',
  };

  public connectedUser: Student | Admin | Lecturer | null = this.admin;
  public projects: ProjectFull[] | null = null;
  public project: ProjectFull | null = null;
  public scheduleDates: ScheduleDates | null = null;
}
