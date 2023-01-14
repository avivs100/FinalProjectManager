import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/models/enums';
import {
  ScheduleDates,
  ScheduleFull,
  Session,
} from 'src/app/models/schedule-models';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { SchduleApiService } from 'src/app/services/schdule-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-schedule-details',
  templateUrl: './schedule-details.component.html',
  styleUrls: ['./schedule-details.component.scss'],
})
export class ScheduleDetailsComponent implements OnInit {
  constructor(
    private state: StateService,
    private api: SchduleApiService,
    private genApi: GeneralApiService
  ) {}

  ngOnInit(): void {}

  public schedule$: Observable<ScheduleFull> = this.api.GetSchedule();
  public dates$: Observable<ScheduleDates> = this.genApi.getScheduleDate();
}
