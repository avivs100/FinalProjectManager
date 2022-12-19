import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import {
  Admin,
  Lecturer,
  ProjectFull,
  Student,
  User,
  UserType,
} from 'src/app/models/modelsInterfaces';
import { LoginService } from 'src/app/services/login-service.service';
import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-projects-page',
  templateUrl: './projects-page.component.html',
  styleUrls: ['./projects-page.component.scss'],
})
export class ProjectsPageComponent implements OnDestroy {
  public userType: UserType | undefined;
  public projectFull$: ProjectFull | undefined;
  public sub: SubSink = new SubSink();
  public user: Student | Lecturer | Admin | null = null;
  constructor(
    private state: StateService,
    private api: StudentApiService,
    private router: Router
  ) {
    this.userType = state.connectedUser?.userType;
    this.user = state.connectedUser;
    this.sub.sink = this.api.getProject(this.user!.id).subscribe((x) => {
      this.state.project = x;
      this.router.navigate(['home/project']);
    });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe;
  }

  navigateToProjectDetails() {
    this.router.navigate(['home/project']);
  }
}
