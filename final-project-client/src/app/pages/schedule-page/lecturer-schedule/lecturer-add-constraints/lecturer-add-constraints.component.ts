import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { StateService } from 'src/app/services/state.service';
import { GeneralApiService } from './../../../../services/general-api.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  LecturerConstarintForDate,
  ScheduleDates,
} from 'src/app/models/schedule-models';

@Component({
  selector: 'app-lecturer-add-constraints',
  templateUrl: './lecturer-add-constraints.component.html',
  styleUrls: ['./lecturer-add-constraints.component.scss'],
})
export class LecturerAddConstraintsComponent implements OnDestroy, OnInit {
  public subs: SubSink = new SubSink();
  public dates: ScheduleDates | null = null;
  public sessions: number[] = [1, 2, 3, 4, 5, 6];
  public SelectedSession1: number[] = [];
  public SelectedSession2: number[] = [];
  public conFromServer: LecturerConstarintForDate | undefined;

  constructor(private state: StateService, private api: LecturerApiService) {}
  ngOnInit(): void {
    this.dates = this.state.scheduleDates;
  }

  saveConstrains() {
    var lecturerConstraints: LecturerConstarintForDate = {
      lecturerId: this.state.connectedUser!.id,
      date1: this.dates!.date1,
      date2: this.dates!.date2,
      sessions1: this.SelectedSession2,
      sessions2: this.SelectedSession1,
    };
    this.subs.sink = this.api
      .PutLecturerConstraints(lecturerConstraints)
      .subscribe((x) => console.log(x, 'response from server'));
    console.log(lecturerConstraints, 'send to server');
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
    console.log(this.SelectedSession1);
    console.log(this.SelectedSession2);
  }
}
