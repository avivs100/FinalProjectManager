import { Component } from '@angular/core';
import { Console } from 'console';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.scss'],
})
export class AdminScheduleComponent {
  public navigateToScheduleDetails() {
    console.log('navigate to schedule-details');
  }
}
