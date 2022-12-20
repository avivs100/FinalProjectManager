import { Injectable, OnInit } from '@angular/core';
import {
  catchError,
  lastValueFrom,
  map,
  observable,
  Observable,
  of,
  pipe,
  Subscriber,
  take,
  tap,
} from 'rxjs';
import {
  Admin,
  Lecturer,
  Student,
  User,
  UserType,
} from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';
import { GeneralApiService } from './general-api.service';
import { LecturerApiService } from './lecturer-api.service';
import { StateService } from './state.service';
import { StudentApiService } from './student-api.service';
import { SubSink } from 'subsink';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class LoginService implements OnInit {
  constructor(
    private generalApi: GeneralApiService,
    private state: StateService,
    private router: Router
  ) {}
  public ob$: Observable<any> | undefined;
  public type: number | undefined;
  private readonly subs: SubSink = new SubSink();

  ngOnInit(): void {}

  public login(id: number, pass: string) {
    this.generalApi
      .login(id, pass)
      .pipe(
        tap((x) => console.log('type from the server is:', x)),
        catchError((err) => {
          return of(this.showError());
        })
      )
      .subscribe((x) => {
        if (x === 0) {
          this.generalApi
            .getAdmin(id)
            .pipe(
              tap((admin) => (this.state.connectedUser = admin)),
              catchError((err) => {
                return of(this.showError());
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 1) {
          this.generalApi
            .getStudent(id)
            .pipe(
              tap((student) => (this.state.connectedUser = student)),
              catchError((err) => {
                return of(this.showError());
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 2) {
          this.generalApi
            .getLecturer(id)
            .pipe(
              tap((lecturer) => (this.state.connectedUser = lecturer)),
              catchError((err) => {
                return of(this.showError());
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 3) {
          this.showError();
        }
      });
  }

  showError() {
    console.log('error');
  }
}
