import { Component } from '@angular/core';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages-page.component.html',
  styleUrls: ['./messages-page.component.scss'],
})
export class MessagesPageComponent {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService) {
    this.userType = loginService.connectedUser?.userType;
  }
}
