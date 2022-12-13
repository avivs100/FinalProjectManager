import { Injectable, OnInit } from '@angular/core';
import { map, Observable, pipe, tap } from 'rxjs';
import { Lecturer, Student, User } from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';
import { LecturerApiService } from './lecturer-api.service';
import { StudentApiService } from './student-api.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService implements OnInit {
  constructor(private data: DataProvaiderService) {}
  public student: Student | null = null;
  public lecturer: Lecturer | null = null;
  ngOnInit(): void {}

  public connectedUser: User | null = this.data.users[1];

  public login(id: number, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    }
    this.connectedUser = user;
    return true;
  }
}
