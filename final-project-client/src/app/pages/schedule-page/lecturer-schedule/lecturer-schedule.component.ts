import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lecturer-schedule',
  templateUrl: './lecturer-schedule.component.html',
  styleUrls: ['./lecturer-schedule.component.scss'],
})
export class LecturerScheduleComponent {
  constructor(private router: Router) {}
  navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }
}
