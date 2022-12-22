import { GeneralApiService } from 'src/app/services/general-api.service';
import { Component } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { LoginService } from 'src/app/services/login-service.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule-page.component.html',
  styleUrls: ['./schedule-page.component.scss'],
})
export class ScheduleComponent {
  public userType: UserType | undefined;
  constructor(public state: StateService, private api: GeneralApiService) {
    this.userType = state.connectedUser?.userType;
  }
}
