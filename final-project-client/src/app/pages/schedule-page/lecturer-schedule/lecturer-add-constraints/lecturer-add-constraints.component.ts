import { GeneralApiService } from './../../../../services/general-api.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ScheduleDates } from 'src/app/models/schedule-models';

@Component({
  selector: 'app-lecturer-add-constraints',
  templateUrl: './lecturer-add-constraints.component.html',
  styleUrls: ['./lecturer-add-constraints.component.scss'],
})
export class LecturerAddConstraintsComponent implements OnDestroy, OnInit {
  public subs: SubSink = new SubSink();
  public dates: ScheduleDates | null = null;
  constructor(private generalApi: GeneralApiService) {}
  ngOnInit(): void {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
}
