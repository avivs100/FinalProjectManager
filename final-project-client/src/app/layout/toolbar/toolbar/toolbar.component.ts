import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { StateService } from 'src/app/services/state.service';
import { UserDetailsDialogComponent } from './user-details-dialog/user-details-dialog.component';

@Component({
  providers: [DialogService],
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  public firstName: string | undefined;
  public lastName: string | undefined;

  constructor(
    private dialog: DialogService,
    private state: StateService,
    private router: Router,
    private messageService: MessageService
  ) {
    this.firstName = state.connectedUser?.firstName;
    this.lastName = state.connectedUser?.lastName;
  }

  navigateToLogin() {
    this.router.navigate(['login']);
  }

  public openRegisterDialog() {
    const ref = this.dialog.open(UserDetailsDialogComponent, {
      header: 'Update details form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      this.showToast(true);
      this.firstName = formData.firstName;
      this.lastName = formData.lastName;
      console.log(formData);
    });
  }

  showToast(x: boolean) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'User Details Updated ',
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
