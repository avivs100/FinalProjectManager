import { SubSink } from 'subsink';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { Component, OnDestroy } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-select-schedule-days-dialog',
  templateUrl: './select-schedule-days-dialog.component.html',
  styleUrls: ['./select-schedule-days-dialog.component.scss'],
})
export class SelectScheduleDaysDialogComponent implements OnDestroy {
  public dates: Date[] = [];
  public subs: SubSink = new SubSink();

  constructor(private api: AdminApiService) {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  public save(): void {
    var dates2: string[] = [];
    this.dates.forEach((x) => {
      dates2.push(x.toISOString());
    });
    console.log(dates2);
    var datesToSend = {
      date1: dates2[0],
      date2: dates2[1],
    };
    this.subs.sink = this.api
      .putScheduleDates(datesToSend)
      .subscribe((x) => console.log(x));
  }

  sendToLecturer() {
    console.log('send email to all lecturer to add constrains');
  }
}
