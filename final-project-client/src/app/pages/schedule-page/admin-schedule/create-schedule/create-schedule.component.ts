import { Component, EventEmitter, Output } from '@angular/core';
import { Subscriber, Subscription } from 'rxjs';

@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule.component.html',
  styleUrls: ['./create-schedule.component.scss'],
})
export class CreateScheduleComponent {
  @Output() public generateScheduleOutput = new EventEmitter();
  @Output() public deleteScheduleOutput = new EventEmitter();
  @Output() public manuelScheduleOutput = new EventEmitter();

  generateSchedule() {
    this.generateScheduleOutput.emit();
  }

  deleteSchedule() {
    this.deleteScheduleOutput.emit();
  }

  nevigateToManualEdit() {
    this.manuelScheduleOutput.emit();
  }
}
