import { Component, Input } from '@angular/core';
import { Session } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-session-details',
  templateUrl: './session-details.component.html',
  styleUrls: ['./session-details.component.scss'],
})
export class SessionDetailsComponent {
  @Input() session: Session | null = null;
}
