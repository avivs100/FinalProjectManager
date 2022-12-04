import { Injectable } from '@angular/core';
import { User } from '../models/model';

@Injectable({
  providedIn: 'root',
})
export class DataGenService {
  public users: User[] = [];

  public genrateLogedStudent() {
    this.users.push({ id: '203639869', pass: '102030' });
  }

  public checkLogin(id: string, pass: string): User | null {
    var user = this.users.find((x) => x.id == id);
    if (user == undefined) {
      return null;
    }
    if (user.pass != pass) {
      return null;
    }
    return user;
  }
}
