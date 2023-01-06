import { Component } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { Student, Lecturer, Admin } from 'src/app/models/users-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.scss'],
})
export class ProjectsPageComponent {
  public userType: UserType | undefined;

  constructor(state: StateService) {
    this.userType = state.connectedUser?.userType;
  }
}
