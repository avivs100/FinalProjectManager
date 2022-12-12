import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';
import { ServerApiService } from 'src/app/services/server-api.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  public userType: UserType | undefined;
  public ob$!: Observable<any[]>;
  public whether: any = [];
  constructor(
    public loginService: LoginService,
    private router: Router,
    private getService: ServerApiService
  ) {}

  ngOnInit(): void {
    if (this.loginService.connectedUser == null) {
      this.router.navigate(['/login']);
    } else {
      this.userType = this.loginService.connectedUser.userType;
    }
    this.ob$ = this.getService.getAllFuckingThings();
  }
}
