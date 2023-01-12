import { Component, OnInit } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import {
  ScheduleDates,
  ScheduleFull,
  Session,
} from 'src/app/models/schedule-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-schedule-details',
  templateUrl: './schedule-details.component.html',
  styleUrls: ['./schedule-details.component.scss'],
})
export class ScheduleDetailsComponent implements OnInit {
  constructor(private state: StateService) {
    this.state.schedule = this.state.returnSceduleFull();
  }
  ngOnInit(): void {
    if (this.state.schedule !== null) {
      this.schedule = this.state.schedule;
      this.dates = this.state.scheduleDates;
      console.log('david', this.schedule);
    }
  }
  public schedule: ScheduleFull | null = null;
  public dates: ScheduleDates | null = null;
}
