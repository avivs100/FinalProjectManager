import { Component } from '@angular/core';
import { UserType } from 'src/app/models/enums';
import { Session } from 'src/app/models/schedule-models';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-schedule-details',
  templateUrl: './schedule-details.component.html',
  styleUrls: ['./schedule-details.component.scss'],
})
export class ScheduleDetailsComponent {
  constructor(private state: StateService) {}
  // public session: Session = {
  //   id: 123456,
  //   responsibleLecturer: {
  //     id: 123,
  //     email: 'david@david',
  //     firstName: 'david',
  //     lastName: 'david',
  //     isActive: true,
  //     password: '123',
  //     userType: UserType.lecturer,
  //     constraints: [
  //       { dataTime: new Date(), id: '12' },
  //       { dataTime: new Date(), id: '12' },
  //     ],
  //   },
  //   lecturer2: {
  //     id: 123,
  //     email: 'david@david',
  //     firstName: 'david',
  //     lastName: 'david',
  //     isActive: true,
  //     password: '123',
  //     userType: UserType.lecturer,
  //     constraints: [
  //       { dataTime: new Date(), id: '12' },
  //       { dataTime: new Date(), id: '12' },
  //     ],
  //   },
  //   lecturer3: {
  //     id: 123,
  //     email: 'david@david',
  //     firstName: 'david',
  //     lastName: 'david',
  //     isActive: true,
  //     password: '123',
  //     userType: UserType.lecturer,
  //     constraints: [
  //       { dataTime: new Date(), id: '12' },
  //       { dataTime: new Date(), id: '12' },
  //     ],
  //   },
  //   //projects: this.state.lecturerProjects!,
  //   sessionNumber: 1,
  // };
}
