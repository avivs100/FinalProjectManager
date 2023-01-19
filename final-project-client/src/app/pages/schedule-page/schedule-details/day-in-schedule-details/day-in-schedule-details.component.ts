import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { DayInSchedule } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-day-in-schedule-details',
  templateUrl: './day-in-schedule-details.component.html',
  styleUrls: ['./day-in-schedule-details.component.scss'],
})
export class DayInScheduleDetailsComponent implements OnChanges {
  ngOnChanges(changes: SimpleChanges): void {
    console.log('day in schedule component : ', this.day);
  }
  @Input() day: DayInSchedule | null = null;
}
