import { LoginService } from 'src/app/services/login-service.service';
import { Component } from '@angular/core';
import { User } from 'src/app/models/modelsInterfaces';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.scss'],
})
export class ToolbarComponent {
  public firstName: string | undefined;
  public lastName: string | undefined;

  constructor(private loginService: LoginService) {
    this.firstName = loginService.connectedUser?.firstName;
    this.lastName = loginService.connectedUser?.lastName;
  }
}
