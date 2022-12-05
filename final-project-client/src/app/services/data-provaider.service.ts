import { Injectable } from '@angular/core';
import { User, UserType } from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class DataProvaiderService {
  public users: User[] = [];
  constructor() {
    this.users.push({
      email: 'avi1aviv2@gmail.com',
      id: 203639869,
      pass: '102030',
      userType: UserType.admin,
      firstName: 'Aviv',
      lastName: 'Shichman',
    });
    this.users.push({
      email: 'sagifishman1@gmail.com',
      id: 205736226,
      pass: '102030',
      userType: UserType.admin,
      firstName: 'Sagi',
      lastName: 'fishman',
    });
  }

  public checkLogin(id: number, pass: string): User | null {
    for (let i = 0; this.users.length; i++) {
      if (this.users[i].id == id && this.users[i].pass == pass) {
        return this.users[i];
      }
    }
    return null;
  }
}
