import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnDestroy,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { MessageService } from 'primeng/api';
import { Observable, Subscriber, Subscription } from 'rxjs';
import { ScheduleDates } from 'src/app/models/schedule-models';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-create-schedule',
  templateUrl: './create-schedule.component.html',
  styleUrls: ['./create-schedule.component.scss'],
})
export class CreateScheduleComponent implements OnDestroy {
  constructor(
    private messageService: MessageService,
    private api: AdminApiService
  ) {}
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  public sub = new SubSink();

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

  sendEmail() {
    console.log('send mail to users');
    this.sub.sink = this.api
      .SendEmailsSchedule()
      .subscribe((x) => this.showToast(x));
  }
  showToast(x: boolean) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'The email has been sent ',
      });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error with email service ',
      });
    }
  }
}
