import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { RegisterFormData } from '../../register/register-page/register-page.component';
import { messageFormData } from './send-message-form/send-message-form.component';

@Component({
  selector: 'app-send-message-dialog',
  templateUrl: './send-message-dialog.component.html',
  styleUrls: ['./send-message-dialog.component.scss'],
})
export class SendMessageDialogComponent {
  constructor(private ref: DynamicDialogRef) {}

  public save(formData: messageFormData): void {
    this.ref.close(formData);
  }
}
