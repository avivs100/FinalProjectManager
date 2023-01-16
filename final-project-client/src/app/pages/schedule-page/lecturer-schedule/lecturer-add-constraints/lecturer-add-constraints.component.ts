import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { StateService } from 'src/app/services/state.service';
import { GeneralApiService } from './../../../../services/general-api.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  LecturerConstarintForDate,
  ScheduleDates,
} from 'src/app/models/schedule-models';
import { MessageService } from 'primeng/api';
import { Observable } from 'rxjs';
export interface DateAndNumberForConstraint {
  num: Number;
  presentation: String;
}

@Component({
  selector: 'app-lecturer-add-constraints',
  templateUrl: './lecturer-add-constraints.component.html',
  styleUrls: ['./lecturer-add-constraints.component.scss'],
})
export class LecturerAddConstraintsComponent implements OnDestroy, OnInit {
  public subs: SubSink = new SubSink();
  public dates: ScheduleDates | null = null;
  public sessions: DateAndNumberForConstraint[] = [
    { num: 1, presentation: '08:00-10:00' },
    { num: 2, presentation: '10:00-12:00' },
    { num: 3, presentation: '12:00-14:00' },
    { num: 4, presentation: '14:00-16:00' },
    { num: 5, presentation: '16:00-18:00' },
  ];
  public SelectedSession1: number[] = [];
  public SelectedSession2: number[] = [];
  public conFromServer: LecturerConstarintForDate | undefined;

  constructor(
    private state: StateService,
    private api: LecturerApiService,
    private msgService: MessageService
  ) {}
  ngOnInit(): void {
    this.dates = this.state.scheduleDates;
  }

  public dates$: Observable<ScheduleDates> = this.api.getScheduleDates();

  saveConstrains() {
    var session2after: number[] = [];
    this.SelectedSession2.forEach((x) => session2after.push(x + 20));
    var lecturerConstraints: LecturerConstarintForDate = {
      lecturerId: this.state.connectedUser!.id,
      date1: this.dates!.date1,
      date2: this.dates!.date2,
      sessions1: this.SelectedSession1,
      sessions2: session2after,
    };
    this.subs.sink = this.api
      .PutLecturerConstraints(lecturerConstraints)
      .subscribe((x) => this.showToast('Successfully Saved'));
    this.SelectedSession1 = [];
    this.SelectedSession2 = [];
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  showToast(msg: string) {
    this.msgService.clear();
    this.msgService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg,
    });
  }
}
