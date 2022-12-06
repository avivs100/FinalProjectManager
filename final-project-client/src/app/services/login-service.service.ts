import { Injectable } from '@angular/core';
import { User, UserType } from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private data: DataProvaiderService) {}

  public connectedUser: User | null = {
    email: 'avi1aviv2@gmail.com',
    id: 203639869,
    pass: '102030',
    userType: UserType.Student,
    firstName: 'Aviv',
    lastName: 'Shichman',
  };

  public login(id: number, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    }
    this.connectedUser = user;
    return true;
  }
}
