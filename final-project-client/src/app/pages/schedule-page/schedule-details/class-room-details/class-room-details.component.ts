import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { ClassSessions } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-class-room-details',
  templateUrl: './class-room-details.component.html',
  styleUrls: ['./class-room-details.component.scss'],
})
export class ClassRoomDetailsComponent implements OnChanges {
  ngOnChanges(changes: SimpleChanges): void {
    console.log('ddddd', this.classSessions);
  }
  @Input() classSessions: ClassSessions | null = null;
}
