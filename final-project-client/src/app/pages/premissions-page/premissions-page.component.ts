import { Lecturer } from './../../models/modelsInterfaces';
import { Observable } from 'rxjs';
import { AdminApiService } from './../../services/admin-api.service';
import { Component, OnInit } from '@angular/core';

@Component({
  templateUrl: './premissions-page.component.html',
  styleUrls: ['./premissions-page.component.scss'],
})
export class PremissionsPageComponent implements OnInit {
  constructor(private api: AdminApiService) {}
  public premissions$: Observable<any[]> = new Observable<any[]>();
  public premissions: any[] = [
    {
      lecturerName: 'david',
      lecturerId: 203639869,
    },
    {
      lecturerName: 'Sagi',
      lecturerId: 147852369,
    },
  ];

  ngOnInit(): void {
    console.log('get premissions from server');
  }
}
