import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public userType: UserType | undefined;
  constructor(public loginService: LoginService, private router: Router) {}

  ngOnInit(): void {
    if (this.loginService.connectedUser == null) {
      this.router.navigate(['/login']);
    } else {
      this.userType = this.loginService.connectedUser.userType;
    }
  }
}
