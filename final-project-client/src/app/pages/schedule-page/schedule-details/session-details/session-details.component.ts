import { Component, Input } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { Session } from 'src/app/models/schedule-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-session-details',
  templateUrl: './session-details.component.html',
  styleUrls: ['./session-details.component.scss'],
})
export class SessionDetailsComponent {
  @Input() session: Session | null = null;
}
