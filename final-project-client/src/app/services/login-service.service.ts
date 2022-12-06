import { Injectable } from '@angular/core';
import { User } from '../models/modelsInterfaces';
import { DataProvaiderService } from './data-provaider.service';

@Injectable({
  providedIn: 'root',
})
export class LoginServiceService {
  constructor(private data: DataProvaiderService) {}

  public connerctedUser: User | null = null;

  public login(id: number, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    }
    this.connerctedUser = user;
    return true;
  }
}
