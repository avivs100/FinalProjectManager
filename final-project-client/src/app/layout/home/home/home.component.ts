import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserType } from 'src/app/models/modelsInterfaces';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { LoginService } from 'src/app/services/login-service.service';
import { ServerApiService } from 'src/app/services/server-api.service';
import { StudentApiService } from 'src/app/services/student-api.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit, OnDestroy {
  public userType: UserType | undefined;

  constructor(
    public loginService: LoginService,
    private router: Router,
    private getService: ServerApiService,
    private studentApi: StudentApiService,
    private lecturerApi: LecturerApiService
  ) {}
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    if (this.loginService.connectedUser == null) {
      this.router.navigate(['/login']);
    } else {
      this.userType = this.loginService.connectedUser.userType;
    }
    console.log('david');
    this.studentApi.getStudent(1).subscribe((x) => console.log(x));
    this.lecturerApi.getLecturer(4).subscribe((x) => console.log(x));
  }
}
