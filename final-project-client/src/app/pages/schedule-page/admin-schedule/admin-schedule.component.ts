import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Console } from 'console';
import { MessageService } from 'primeng/api';
import { Observable, Subscription } from 'rxjs';
import { ScheduleDates, ScheduleFull } from 'src/app/models/schedule-models';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { SchduleApiService } from 'src/app/services/schdule-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.scss'],
})
export class AdminScheduleComponent implements OnDestroy, OnInit {
  constructor(
    private router: Router,
    protected state: StateService,
    private sceduleApi: SchduleApiService,
    private messageService: MessageService,
    private adminApi: AdminApiService
  ) {}
  ngOnInit(): void {
    this.subs.add(
      this.adminApi.getScheduleDates().subscribe((x) => {
        this.dates = x;
        console.log('david', x, 'david');
        if (!x.date1) this.dates = null;
      })
    );
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  public scedule$ = this.sceduleApi.GetSchedule();
  public subs: Subscription = new Subscription();
  public dates$: Observable<ScheduleDates> | null =
    this.adminApi.getScheduleDates();
  public dates: ScheduleDates | null = null;

  public navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }

  generateSchedule() {
    console.log('generate schedule');
    this.subs.add(
      this.sceduleApi.GenerateSchedule().subscribe((x) => {
        this.scedule$ = this.sceduleApi.GetSchedule();
        this.showToast('Schedule is Created ');
      })
    );
  }

  deleteSchedule() {
    console.log('delete schedule');
    this.subs.add(
      this.sceduleApi.DeleteSchedule().subscribe((x) => {
        console.log('schedule is removed? : ', x);
        this.showToast('your schedule is deleted ' + x);
        this.scedule$ = this.sceduleApi.GetSchedule();
      })
    );
  }

  nevigateToManualEdit() {
    console.log('navigate to manuel editing schedule page');
  }

  onDatesSave() {
    this.subs.add(
      this.adminApi.getScheduleDates().subscribe((x) => (this.dates = x))
    );
  }

  showToast(msg: string) {
    this.messageService.clear();
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg,
    });
  }
}
