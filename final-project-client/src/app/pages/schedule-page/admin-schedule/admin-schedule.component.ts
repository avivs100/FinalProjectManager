import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Console } from 'console';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.scss'],
})
export class AdminScheduleComponent {
  constructor(private router: Router) {}
  public navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }
}
