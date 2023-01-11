import { ScheduleFull } from './../../models/schedule-models';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { Component, OnInit } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { LoginService } from 'src/app/services/login-service.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule-page.component.html',
  styleUrls: ['./schedule-page.component.scss'],
})
export class ScheduleComponent implements OnInit {
  public userType: UserType | undefined;
  constructor(public state: StateService, private api: GeneralApiService) {
    this.userType = state.connectedUser?.userType;
  }
  ngOnInit(): void {
    this.schedule = this.state.returnSceduleFull();
  }
  public schedule: ScheduleFull | null = null;

  trySchedule() {
    this.schedule = this.state.returnSceduleFull();
  }
}
