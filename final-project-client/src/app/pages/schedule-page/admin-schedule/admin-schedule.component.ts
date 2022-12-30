import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Console } from 'console';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-admin-schedule',
  templateUrl: './admin-schedule.component.html',
  styleUrls: ['./admin-schedule.component.scss'],
})
export class AdminScheduleComponent {
  constructor(private router: Router, protected state: StateService) {}
  public navigateToScheduleDetails() {
    this.router.navigate(['home/schedule-details']);
  }
}
