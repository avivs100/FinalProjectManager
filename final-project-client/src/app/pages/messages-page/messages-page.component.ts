import { Component } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages-page.component.html',
  styleUrls: ['./messages-page.component.scss'],
})
export class MessagesPageComponent {
  public userType: UserType | undefined;
  constructor(public state: StateService) {
    this.userType = state.connectedUser?.userType;
  }
}
