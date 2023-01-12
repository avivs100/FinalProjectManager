import { Component, Input, OnChanges } from '@angular/core';
import { Session } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-session-details',
  templateUrl: './session-details.component.html',
  styleUrls: ['./session-details.component.scss'],
})
export class SessionDetailsComponent implements OnChanges {
  ngOnChanges(): void {
    console.log('eee', this.session);
  }
  @Input() session: Session | null = null;
}
