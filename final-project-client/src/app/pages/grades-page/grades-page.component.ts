import { Component } from '@angular/core';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-grades',
  templateUrl: './grades-page.component.html',
  styleUrls: ['./grades-page.component.scss'],
})
export class GradesComponent {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService) {
    this.userType = loginService.connectedUser?.userType;
  }
}
