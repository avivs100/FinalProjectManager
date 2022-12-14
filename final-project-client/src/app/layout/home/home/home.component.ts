import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { LoginService } from 'src/app/services/login-service.service';
import { ServerApiService } from 'src/app/services/server-api.service';
import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, OnDestroy {
  public userType: UserType | undefined;

  constructor(private router: Router, private state: StateService) {}
  ngOnDestroy(): void {
    console.log('home page on destroy');
  }

  ngOnInit(): void {
    if (this.state.connectedUser == null) {
      console.log(this.state.connectedUser);
      this.router.navigate(['/login']);
    } else {
      this.userType = this.state.connectedUser.userType;
      console.log(this.state.connectedUser);
    }
  }
}
