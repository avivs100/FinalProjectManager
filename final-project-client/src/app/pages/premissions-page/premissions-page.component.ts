import { delay, Observable } from 'rxjs';
import { AdminApiService } from './../../services/admin-api.service';
import { Component, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { premission } from 'src/app/models/users-models';
import { StateService } from 'src/app/services/state.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: './premissions-page.component.html',
  styleUrls: ['./premissions-page.component.scss'],
})
export class PremissionsPageComponent implements OnInit {
  constructor(
    private api: AdminApiService,
    private state: StateService,
    private router: Router
  ) {}
  public subs: SubSink = new SubSink();
  public premissions$ = this.api.getPremissions();
  public premissions: premission[] | null = null;

  ngOnInit(): void {
    this.premissions = this.state.premissions;
    console.log('david');
  }

  aproveLecturerPremission(id: number) {
    this.subs.sink = this.api.aproveLecturerPremission(id).subscribe((x) => {
      console.log('aproved lecturer with id ', id, x);
      this.premissions$ = this.api.getPremissions();
    });
  }

  deleteLecturerPremission(id: number) {
    this.subs.sink = this.api.deleteLecturerPremission(id).subscribe((x) => {
      console.log('deleted lecturer premission with id ', id, x);
      this.premissions$ = this.api.getPremissions();
    });
  }
}
