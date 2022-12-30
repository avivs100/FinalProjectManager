import { DialogService } from 'primeng/dynamicdialog';
import { Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';

import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';
import { ProjectFull } from 'src/app/models/project-grade-models';
import { CreateProjectProposalDialogComponent } from '../create-project-proposal-dialog/create-project-proposal-dialog.component';
import { filter } from 'rxjs';

@Component({
  providers: [DialogService],
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent implements OnDestroy, OnInit {
  public sub: SubSink = new SubSink();

  public project: ProjectFull | null = null;
  constructor(
    private state: StateService,
    private api: StudentApiService,
    private router: Router,
    private dialog: DialogService
  ) {}
  ngOnInit(): void {
    this.project = this.state.project;
    if (this.project !== null) this.navigateToProjectDetails();
  }
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  openProposalDialog() {
    console.log('open dialog');
    const ref = this.dialog.open(CreateProjectProposalDialogComponent, {
      header: 'Register Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      console.log(formData);
      this.sub.sink = this.api
        .AddNewProjectProposal(formData)
        .subscribe((x) => console.log('response from server', x));
    });
  }

  navigateToProjectDetails() {
    this.router.navigate(['home/project']);
  }
}
