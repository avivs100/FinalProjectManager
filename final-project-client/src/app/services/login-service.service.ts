import { Injectable } from '@angular/core';
import { User, UserType } from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private data: DataProvaiderService) {}

  public connectedUser: User | null = this.data.users[0];

  public login(id: number, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    }
    this.connectedUser = user;
    return true;
  }
}
