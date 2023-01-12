import { Component, Input } from '@angular/core';
import { DayInSchedule } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-day-in-schedule-details',
  templateUrl: './day-in-schedule-details.component.html',
  styleUrls: ['./day-in-schedule-details.component.scss'],
})
export class DayInScheduleDetailsComponent {
  @Input() day: DayInSchedule | null = null;
}
