import { Component } from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';

@Component({
  providers: [DialogService],
  selector: 'app-admin-messages',
  templateUrl: './admin-messages.component.html',
  styleUrls: ['./admin-messages.component.scss'],
})
export class AdminMessagesComponent {
  constructor(private dialog: DialogService) {}

  public openRegisterDialog() {
    const ref = this.dialog.open(SendMessageDialogComponent, {
      header: 'Message Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      console.log(formData);
    });
  }
}
