import { Component } from '@angular/core';
import {
  Admin,
  Lecturer,
  Student,
  User,
  UserType,
} from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.scss'],
})
export class ProjectsPageComponent {
  public userType: UserType | undefined;
  public user: Student | Lecturer | Admin | null = null;
  constructor(public state: StateService) {
    this.userType = state.connectedUser?.userType;
    this.user = state.connectedUser;
  }
}
