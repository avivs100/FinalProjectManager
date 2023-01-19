import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ScheduleFull } from 'src/app/models/schedule-models';
import { SchduleApiService } from 'src/app/services/schdule-api.service';

@Component({
  selector: 'app-lecturer-schedule',
  templateUrl: './lecturer-schedule.component.html',
  styleUrls: ['./lecturer-schedule.component.scss'],
})
export class LecturerScheduleComponent {
  constructor(private router: Router, public api: SchduleApiService) {}
  public schedule$: Observable<ScheduleFull> = this.api.GetSchedule();
  navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }
}
