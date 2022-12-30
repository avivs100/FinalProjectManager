import { Component } from '@angular/core';

@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule.component.html',
  styleUrls: ['./create-schedule.component.scss'],
})
export class CreateScheduleComponent {
  generateSchedule() {
    console.log('need to generate schedule');
  }

  deleteSchedule() {
    console.log('need to delete schedule');
  }

  nevigateToManualEdit() {
    console.log('need to nevigate To Manual Edit');
  }
}
