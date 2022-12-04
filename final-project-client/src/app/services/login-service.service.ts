import { Injectable } from '@angular/core';
import { User } from '../models/model';
import { DataGenService } from './data-gen.service';

@Injectable({
  providedIn: 'root',
})
export class LoginServiceService {
  constructor(private data: DataGenService) {}

  public connerctedUser: User | null = null;

  public login(id: string, pass: string): boolean {
    var user = this.data.checkLogin(id, pass);
    if (user == null) {
      return false;
    }
    this.connerctedUser = user;
    return true;
  }
}
