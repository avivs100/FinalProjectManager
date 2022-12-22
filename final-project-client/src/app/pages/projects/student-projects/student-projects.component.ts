import { Router } from '@angular/router';
import { Component, OnDestroy } from '@angular/core';

import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';
import { ProjectFull } from 'src/app/models/project-grade-models';

@Component({
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent implements OnDestroy {
  public projectFull$: ProjectFull | undefined;
  public sub: SubSink = new SubSink();

  public project: ProjectFull | null = null;
  constructor(
    private state: StateService,
    private api: StudentApiService,
    private router: Router
  ) {
    this.sub.sink = this.api
      .getProject(this.state.connectedUser!.id)
      .subscribe((x) => {
        this.state.project = x;
        this.navigateToProjectDetails();
      });
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  navigateToProjectDetails() {
    this.router.navigate(['home/project']);
  }
}
