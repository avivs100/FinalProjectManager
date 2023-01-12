import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Console } from 'console';
import { Subscription } from 'rxjs';
import { SchduleApiService } from 'src/app/services/schdule-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.scss'],
})
export class AdminScheduleComponent implements OnDestroy {
  constructor(
    private router: Router,
    protected state: StateService,
    private sceduleApi: SchduleApiService
  ) {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public subs: Subscription = new Subscription();

  public navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }

  generateSchedule() {
    console.log('generate schedule');
    this.subs.add(
      this.sceduleApi
        .GenerateSchedule()
        .subscribe((x) => (this.state.schedule = x))
    );
  }

  deleteSchedule() {
    console.log('delete schedule');
  }

  nevigateToManualEdit() {
    console.log('navigate to manuel editing schedule page');
  }
}
