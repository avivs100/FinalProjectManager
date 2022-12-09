import { Component } from '@angular/core';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-submissions',
  templateUrl: './submissions-page.component.html',
  styleUrls: ['./submissions-page.component.scss'],
})
export class SubmissionsComponent {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService) {
    this.userType = loginService.connectedUser?.userType;
  }
}
