import { Component } from '@angular/core';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.scss'],
})
export class ProjectsPageComponent {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService) {
    this.userType = loginService.connectedUser?.userType;
  }
}
