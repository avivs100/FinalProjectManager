import { Component, EventEmitter, Output } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Subscriber, Subscription } from 'rxjs';

@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule.component.html',
  styleUrls: ['./create-schedule.component.scss'],
})
export class CreateScheduleComponent {
  constructor(private messageService: MessageService) {}
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

  showToast(msg: string) {
    this.messageService.clear();
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg,
    });
  }
}
