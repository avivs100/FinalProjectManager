import { Component, Input, OnChanges } from '@angular/core';
import { Session } from 'src/app/models/schedule-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-session-details',
  templateUrl: './session-details.component.html',
  styleUrls: ['./session-details.component.scss'],
})
export class SessionDetailsComponent implements OnChanges {
  constructor(private state: StateService) {}
  ngOnChanges(): void {
    console.log('eee', this.session);
    switch (this.number) {
      case 1:
        this.time = '08:00 - 10:00';
        break;
      case 2:
        this.time = '10:00 - 12:00';
        break;
      case 3:
        this.time = '12:00 - 14:00';
        break;
      case 4:
        this.time = '14:00 - 16:00';
        break;
      case 5:
        this.time = '16:00 - 18:00';
        break;
      default:
        break;
    }
    if (
      this.session!.lecturer2.id == this.state.connectedUser!.id ||
      this.session!.lecturer3.id == this.state.connectedUser!.id ||
      this.session!.responsibleLecturer.id == this.state.connectedUser!.id
    ) {
      this.itsMySession = true;
    }
    this.session!.projects.forEach((x) => {
      if (
        x.projectFull.student1.id == this.state.connectedUser!.id ||
        x.projectFull!.student2.id == this.state.connectedUser!.id
      ) {
        this.itsMySession = true;
      }
    });
  }
  @Input() session: Session | null = null;
  @Input() number: Number | null = null;
  public time: string = '';
  public itsMySession: boolean = false;
}
