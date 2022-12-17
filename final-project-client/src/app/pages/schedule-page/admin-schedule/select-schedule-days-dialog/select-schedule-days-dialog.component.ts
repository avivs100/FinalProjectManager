import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-select-schedule-days-dialog',
  templateUrl: './select-schedule-days-dialog.component.html',
  styleUrls: ['./select-schedule-days-dialog.component.scss'],
})
export class SelectScheduleDaysDialogComponent {
  dates: Date[] = [];

  public save(): void {
    console.log(this.dates);
    console.log('david');
  }

  sendToLecturer() {
    console.log('send email to all lecturer to add constrains');
  }
}
