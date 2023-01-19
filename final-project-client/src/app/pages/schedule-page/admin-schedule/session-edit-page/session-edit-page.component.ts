import { Component } from '@angular/core';
import { Session } from 'src/app/models/schedule-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-session-edit-page',
  templateUrl: './session-edit-page.component.html',
  styleUrls: ['./session-edit-page.component.scss'],
})
export class SessionEditPageComponent {
  public session: Session | null = null;
  constructor(private state: StateService) {
    this.session = this.state.session;
  }
  public isEdit = false;
}
