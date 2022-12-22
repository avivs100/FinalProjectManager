import { SubSink } from 'subsink';
import { ScheduleDates } from './../../../models/schedule-models';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { UserType } from 'src/app/models/enums';
import { StateService } from 'src/app/services/state.service';
import { Subscriber, catchError, EmptyError, of } from 'rxjs';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, OnDestroy {
  public userType: UserType | undefined;
  public sub: SubSink = new SubSink();
  constructor(
    private router: Router,
    private state: StateService,
    private api: GeneralApiService
  ) {}
  ngOnDestroy(): void {
    this.sub.unsubscribe;
  }

  ngOnInit(): void {
    if (this.state.connectedUser == null) {
      this.router.navigate(['/login']);
    } else {
      this.userType = this.state.connectedUser.userType;
      this.sub.sink = this.api
        .getScheduleDate()
        .pipe(
          catchError((err) => {
            console.log(err);
            return of(null);
          })
        )
        .subscribe((x) => {
          this.state.scheduleDates = x;
          console.log(x);
        });
      this.router.navigate(['/home/welcome']);
    }
  }
}
