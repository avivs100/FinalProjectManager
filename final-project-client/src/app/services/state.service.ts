import { ScheduleDates } from './../models/schedule-models';
import { Injectable, OnDestroy } from '@angular/core';
import { ProjectFull } from '../models/project-grade-models';
import { Admin, Lecturer, premission, Student } from '../models/users-models';
import { AdminApiService } from './admin-api.service';
import { LecturerApiService } from './lecturer-api.service';
import { StudentApiService } from './student-api.service';
import { SubSink } from 'subsink';
import { GeneralApiService } from './general-api.service';
import { catchError, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StateService implements OnDestroy {
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
  public subs: SubSink = new SubSink();
  public connectedUser: Student | Admin | Lecturer | null = this.admin;
  public projects: ProjectFull[] | null = null;
  public project: ProjectFull | null = null;
  public scheduleDates: ScheduleDates | null = null;
  public premissions: premission[] | null = null;
  public lecturers: Lecturer[] | null = null;
  public students: Student[] | null = null;

  constructor(
    private api: GeneralApiService,
    private adminApi: AdminApiService,
    private lecturerApi: LecturerApiService,
    private studentApi: StudentApiService
  ) {}

  userLogedIn() {
    console.log('any user loged in');
    this.subs.sink = this.api
      .getScheduleDate()
      .pipe(
        catchError((err) => {
          console.log(err);
          return of(null);
        })
      )
      .subscribe((x) => {
        this.scheduleDates = x;
      });
  }

  adminLogedIn() {
    console.log('admin service start fetch data');
    this.subs.sink = this.adminApi
      .getAllLecturer()
      .subscribe((x) => (this.lecturers = x));

    this.subs.sink = this.adminApi
      .getProjects()
      .subscribe((x) => (this.projects = x));

    this.subs.sink = this.adminApi
      .getStudents()
      .subscribe((x) => (this.students = x));
  }

  LecturerLogedIn() {
    console.log('lecturer service start fetch data');
  }

  StudentLogedIn() {
    console.log('student service start fetch data');
  }

  //unsubscribe from all subs
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
