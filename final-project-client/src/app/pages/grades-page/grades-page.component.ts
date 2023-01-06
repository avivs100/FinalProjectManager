import { Component } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-grades',
  templateUrl: './grades-page.component.html',
  styleUrls: ['./grades-page.component.scss'],
})
export class GradesComponent {
  public userType: UserType | undefined;
  constructor(public state: StateService) {
    this.userType = state.connectedUser?.userType;
  }
}
