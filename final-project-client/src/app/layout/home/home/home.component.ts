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
      this.anyUserLogedIn();
      this.router.navigate(['/home/welcome']);
    }
  }

  anyUserLogedIn() {
    this.userType = this.state.connectedUser!.userType;
    this.state.userLogedIn();
    if (this.userType == 0) this.state.adminLogedIn();
    else if (this.userType == 1) this.state.StudentLogedIn();
    else if (this.userType == 2) this.state.LecturerLogedIn();
    else console.log('error');
  }
}
