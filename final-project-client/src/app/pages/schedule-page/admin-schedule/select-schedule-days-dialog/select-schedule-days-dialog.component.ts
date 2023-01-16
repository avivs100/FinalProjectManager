import { SubSink } from 'subsink';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { Component, OnDestroy } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { StateService } from 'src/app/services/state.service';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { Observable } from 'rxjs';
import { ScheduleDates } from 'src/app/models/schedule-models';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-select-schedule-days-dialog',
  templateUrl: './select-schedule-days-dialog.component.html',
  styleUrls: ['./select-schedule-days-dialog.component.scss'],
})
export class SelectScheduleDaysDialogComponent implements OnDestroy {
  public dates: Date[] = [];
  public subs: SubSink = new SubSink();

  constructor(
    private api: AdminApiService,
    protected state: StateService,
    private genApi: GeneralApiService,
    private messageService: MessageService
  ) {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public dates$: Observable<ScheduleDates> = this.genApi.getScheduleDate();

  public save(): void {
    var datesStr: string[] = [];
    this.dates.forEach((x) => {
      var d1 = new Date(
        new Date(x.getTime() - x.getTimezoneOffset() * 60 * 1000).toUTCString()
      );
      datesStr.push(d1.toISOString());
    });
    console.log(datesStr);
    var datesToSend = {
      date1: datesStr[0],
      date2: datesStr[1],
    };
    this.subs.sink = this.api.putScheduleDates(datesToSend).subscribe((x) => {
      this.showToast('Schedule Dates Are Saved ');
      this.dates$ = this.genApi.getScheduleDate();
    });
  }

  sendToLecturer() {
    console.log('send email to all lecturer to add constrains');
  }

  showToast(msg: string) {
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg,
    });
  }
}
