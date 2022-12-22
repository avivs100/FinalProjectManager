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

  constructor(private state: StateService) {}
  ngOnInit(): void {
    this.dates = this.state.scheduleDates;
  }

  saveConstrains() {
    var con1: LecturerConstarintForDate = {
      lecturerId: this.state.connectedUser!.id,
      date: this.dates!.date2,
      sessions: this.SelectedSession2,
    };
    var con2: LecturerConstarintForDate = {
      lecturerId: this.state.connectedUser!.id,
      date: this.dates!.date1,
      sessions: this.SelectedSession1,
    };
    var lecturerConstrains = [con1, con2];
    console.log(con1);
    console.log(con2);
    console.log(lecturerConstrains);
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
    console.log(this.SelectedSession1);
    console.log(this.SelectedSession2);
  }
}
