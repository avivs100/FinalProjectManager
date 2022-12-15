import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-select-schedule-days',
  templateUrl: './select-schedule-days.component.html',
  styleUrls: ['./select-schedule-days.component.scss'],
})
export class SelectScheduleDaysComponent {
  constructor(private ref: DynamicDialogRef) {}

  public save(formData: any): void {
    this.ref.close(formData);
  }
}
