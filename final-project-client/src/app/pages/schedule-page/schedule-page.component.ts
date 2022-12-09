import { Component } from '@angular/core';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule-page.component.html',
  styleUrls: ['./schedule-page.component.scss'],
})
export class ScheduleComponent {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService) {
    this.userType = loginService.connectedUser?.userType;
  }
}
