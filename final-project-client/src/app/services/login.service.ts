import { Injectable } from '@angular/core';
import { User } from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  public connectedUser: User | null = null;
  constructor(private data: DataProvaiderService) {}

  public login(id: number, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    } else {
      this.connectedUser = user;
      return true;
    }
  }
}
