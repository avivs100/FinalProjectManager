import { Lecturer, premission } from './../../models/modelsInterfaces';
import { Observable } from 'rxjs';
import { AdminApiService } from './../../services/admin-api.service';
import { Component, OnInit } from '@angular/core';
import { SubSink } from 'subsink';

@Component({
  templateUrl: './premissions-page.component.html',
  styleUrls: ['./premissions-page.component.scss'],
})
export class PremissionsPageComponent implements OnInit {
  constructor(private api: AdminApiService) {}
  public subs: SubSink = new SubSink();
  public premissions$: Observable<premission[]> = this.api.getPremissions();

  ngOnInit(): void {
    //this.api.getAllLecturer().subscribe((x) => console.log(x));
    console.log('get premissions from server');
  }

  aproveLecturerPremission(id: number) {
    this.subs.sink = this.api
      .aproveLecturerPremission(id)
      .subscribe((x) => console.log('aproved lecturer with id ', id, x));
  }

  deleteLecturerPremission(id: number) {
    this.subs.sink = this.api
      .deleteLecturerPremission(id)
      .subscribe((x) =>
        console.log('deleted lecturer premission with id ', id, x)
      );
  }
}
