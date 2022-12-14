import { Component } from '@angular/core';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  public firstName: string | undefined;
  public lastName: string | undefined;

  constructor(state: StateService) {
    this.firstName = state.connectedUser?.firstName;
    this.lastName = state.connectedUser?.lastName;
  }
}
