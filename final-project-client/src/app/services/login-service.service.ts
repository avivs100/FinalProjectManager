import { Injectable, OnInit } from '@angular/core';
import { map, observable, Observable, pipe, Subscriber, tap } from 'rxjs';
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

@Injectable({
  providedIn: 'root',
})
export class LoginService implements OnInit {
  constructor(
    private generalApi: GeneralApiService,
    private state: StateService
  ) {}
  public type: UserType | null = null;
  private readonly subs: SubSink = new SubSink();
  ngOnInit(): void {}

  public login(id: number, pass: string): boolean {
    const sub = this.generalApi
      .login(id, pass)
      .subscribe((x: UserType) => (this.type = x));

    console.log('beforeswitch');
    console.log(this.type);
    switch (this.type) {
      case 0: {
        console.log('InSwitch1');
        this.subs.sink = this.generalApi
          .getAdmin(id)
          .subscribe((a) => (this.state.connectedUser = a));
        break;
      }
      case 1: {
        console.log('InSwitch2');
        this.subs.sink = this.generalApi
          .getStudent(id)
          .subscribe((s) => (this.state.connectedUser = s));
        break;
      }
      case 2: {
        console.log('InSwitch3');
        this.subs.sink = this.generalApi
          .getLecturer(id)
          .subscribe((l) => (this.state.connectedUser = l));
        break;
      }
      case 3: {
        console.log('InSwitch4');
        return false;
      }
    }
    this.subs.unsubscribe();
    return true;
  }
}
