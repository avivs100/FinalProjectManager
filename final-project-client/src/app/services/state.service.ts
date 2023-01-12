import {
  ClassSessions,
  DayInSchedule,
  ProjectInSession,
  ScheduleDates,
  ScheduleFull,
  Session,
} from './../models/schedule-models';
import { Injectable, OnDestroy } from '@angular/core';
import {
  ProjectFull,
  ProjectProposalDetailsWithStatus,
} from '../models/project-grade-models';
import { Admin, Lecturer, premission, Student } from '../models/users-models';
import { AdminApiService } from './admin-api.service';
import { LecturerApiService } from './lecturer-api.service';
import { StudentApiService } from './student-api.service';
import { SubSink } from 'subsink';
import { GeneralApiService } from './general-api.service';
import { catchError, of, throwError } from 'rxjs';

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
    email: 'sagifishman1@gmail.com',
  };
  public subs: SubSink = new SubSink();
  public connectedUser: Student | Admin | Lecturer | null = this.admin;
  public projects: ProjectFull[] | null = null;
  public project: ProjectFull | null = null;
  public lecturerProjects: ProjectFull[] | null = null;
  public scheduleDates: ScheduleDates | null = null;
  public premissions: premission[] | null = null;
  public lecturers: Lecturer[] | null = null;
  public students: Student[] | null = null;
  public schedule: ScheduleFull | null = null;
  public proposals: ProjectProposalDetailsWithStatus[] | null = null;
  public selectedProposal: ProjectProposalDetailsWithStatus | null = null;
  public admins: Admin[] | null = null;
  public proposalAfterAprove: ProjectProposalDetailsWithStatus[] | null = null;

  public errorMessage = '';

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
        console.log('app schedule dates from server', this.scheduleDates);
      });

    this.subs.sink = this.adminApi.getStudents().subscribe((x) => {
      this.students = x;
      console.log('students from server', this.students);
    });

    this.subs.sink = this.adminApi.getAllLecturer().subscribe((x) => {
      this.lecturers = x;
      console.log('lecturers from server', this.lecturers);
    });

    this.subs.sink = this.api.getProposals().subscribe((x) => {
      this.proposals = x;
      console.log('proposals from server', this.proposals);
    });

    this.subs.sink = this.adminApi.getProjects().subscribe((x) => {
      this.projects = x;
      console.log('projects from server', this.projects);
    });
  }

  adminLogedIn() {
    console.log('admin service start fetch data');

    this.subs.sink = this.adminApi.getProjects().subscribe((x) => {
      this.projects = x;
      console.log('projects from server', this.projects);
    });

    this.subs.sink = this.adminApi.getPremissions().subscribe((x) => {
      this.premissions = x;
      console.log('premissions from server', this.premissions);
    });

    this.subs.sink = this.adminApi.getProposalsAfterAprove().subscribe((x) => {
      this.proposalAfterAprove = x;
      console.log('proposals from server', this.proposalAfterAprove);
    });
  }

  LecturerLogedIn() {
    console.log('lecturer service start fetch data');
    this.subs.sink = this.lecturerApi
      .getLecturerProjects(this.connectedUser!.id)
      .subscribe((x) => {
        this.lecturerProjects = x;
        console.log('lectuerer projects from server', this.lecturerProjects);
      });
  }

  StudentLogedIn() {
    console.log('student service start fetch data');
    this.subs.sink = this.studentApi
      .getProject(this.connectedUser!.id)
      .subscribe((x) => {
        this.project = x;
        console.log('student project from server', this.project);
      });
  }

  //unsubscribe from all subs
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  returnSceduleFull(): ScheduleFull {
    var schedule = {
      dayOne: this.returnDayInSchedule(false, 1),
      dayTwo: this.returnDayInSchedule(false, 2),
      id: 12344,
    };

    console.log(schedule);
    return schedule;
  }

  returnDayInSchedule(day: boolean, id: number): DayInSchedule {
    var dayOne: DayInSchedule = {
      classSessions1: this.returnClassSessions('1', 1),
      classSessions2: this.returnClassSessions('2', 2),
      classSessions3: this.returnClassSessions('3', 3),
      classSessions4: this.returnClassSessions('4', 4),
      day: day,
      id: id,
    };
    return dayOne;
  }

  returnSession(id: number, sessionNum: number): Session {
    return {
      id: id,
      lecturer2: this.lecturer,
      lecturer3: this.lecturer,
      projects: this.returnProjectInSession(),
      responsibleLecturer: this.lecturer,
      sessionNumber: sessionNum,
    };
  }

  returnProjectInSession(): ProjectInSession[] {
    var projectInSession = [
      {
        order: 0,
        project: this.projects![0],
      },
      {
        order: 1,
        project: this.projects![1],
      },
      {
        order: 2,
        project: this.projects![2],
      },
      {
        order: 3,
        project: this.projects![3],
      },
      {
        order: 4,
        project: this.projects![4],
      },
      {
        order: 5,
        project: this.projects![5],
      },
    ];

    return projectInSession;
  }

  returnClassSessions(className: string, id: number): ClassSessions {
    return <ClassSessions>{
      className: className,
      Session1: this.returnSession(1, 1),
      Session2: this.returnSession(2, 2),
      Session3: this.returnSession(3, 3),
      Session4: this.returnSession(4, 4),
      Session5: this.returnSession(5, 5),
      id: id,
    };
  }
}
