import { LoginService } from 'src/app/services/login-service.service';
import { Component } from '@angular/core';
import { User } from 'src/app/models/modelsInterfaces';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  public firstName: string | undefined;
  public lastName: string | undefined;

  constructor(private state: StateService) {
    this.firstName = state.connectedUser?.firstName;
    this.lastName = state.connectedUser?.lastName;
  }
}
