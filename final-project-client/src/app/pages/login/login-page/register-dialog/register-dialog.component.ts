import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { RegisterFormData } from './register-form/register-form.component';

@Component({
  selector: 'app-register-dialog',
  templateUrl: './register-dialog.component.html',
  styleUrls: [],
})
export class RegisterDialogComponent {
  constructor(private ref: DynamicDialogRef) {}

  public save(formData: RegisterFormData): void {
    this.ref.close(formData);
  }
}
