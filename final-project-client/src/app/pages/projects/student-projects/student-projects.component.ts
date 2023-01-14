import { DialogService } from 'primeng/dynamicdialog';
import { Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';

import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';
import { ProjectFull } from 'src/app/models/project-grade-models';
import { CreateProjectProposalDialogComponent } from '../create-project-proposal-dialog/create-project-proposal-dialog.component';
import { filter } from 'rxjs';
import { MessageService } from 'primeng/api';

@Component({
  providers: [DialogService],
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent implements OnDestroy, OnInit {
  public subs: SubSink = new SubSink();

  public project: ProjectFull | null = null;
  constructor(
    private state: StateService,
    private api: StudentApiService,
    private router: Router,
    private dialog: DialogService,
    private messageService: MessageService
  ) {}
  ngOnInit(): void {
    this.project = this.state.project;
    if (this.project !== null) this.navigateToProjectDetails();
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  openProposalDialog() {
    const ref = this.dialog.open(CreateProjectProposalDialogComponent, {
      header: 'Project Proposal Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      console.log(formData);

      this.subs.sink = this.api
        .AddNewProjectProposal(formData)
        .subscribe((x) => {
          console.log('response from server', x);
          this.showToast(
            'your proposal is sent to lecturer with name' + x.projectName
          );
        });
    });
  }

  navigateToProjectDetails() {
    this.router.navigate(['home/project']);
  }

  showToast(msg: string) {
    this.messageService.clear();
    this.messageService.add({
      severity: 'success',
      summary: 'Success',
      detail: msg,
    });
  }
}
