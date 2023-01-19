import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { userDetailsFormData } from './user-details-form/user-details-form.component';

@Component({
  templateUrl: './user-details-dialog.component.html',
})
export class UserDetailsDialogComponent {
  constructor(private ref: DynamicDialogRef) {}

  public save(formData: userDetailsFormData): void {
    this.ref.close(formData);
  }
}
