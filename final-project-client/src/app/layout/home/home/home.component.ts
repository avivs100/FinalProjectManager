import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserType } from 'src/app/models/enums';
import { StateService } from 'src/app/services/state.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public userType: UserType | undefined;

  constructor(private router: Router, private state: StateService) {}

  ngOnInit(): void {
    if (this.state.connectedUser == null) {
      this.router.navigate(['/login']);
    } else {
      this.userType = this.state.connectedUser.userType;
      this.router.navigate(['/home/welcome']);
      console.log(this.state.connectedUser);
    }
  }
}
