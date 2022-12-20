import { Router } from '@angular/router';
import { Component, Input, OnDestroy } from '@angular/core';
import { ProjectFull, User } from 'src/app/models/modelsInterfaces';
import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent implements OnDestroy {
  @Input() public user: User | null = null;
  public projectFull$: ProjectFull | undefined;
  public sub: SubSink = new SubSink();

  public project: ProjectFull | null = null;
  constructor(
    private state: StateService,
    private api: StudentApiService,
    private router: Router
  ) {
    this.sub.sink = this.api.getProject(this.user!.id).subscribe((x) => {
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
