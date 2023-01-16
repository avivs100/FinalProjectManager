import { ScheduleFull } from './../../../models/schedule-models';
import { Observable, Subscription } from 'rxjs';
import { SchduleApiService } from 'src/app/services/schdule-api.service';
import { Component, OnChanges, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-schedule',
  templateUrl: './student-schedule.component.html',
  styleUrls: ['./student-schedule.component.scss'],
})
export class StudentScheduleComponent {
  constructor(private sceduleApi: SchduleApiService, private router: Router) {}
  public schedule$: Observable<ScheduleFull> = this.sceduleApi.GetSchedule();

  navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }
}
