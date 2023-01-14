import { StateService } from 'src/app/services/state.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';
import { Student, Lecturer } from 'src/app/models/users-models';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { SubSink } from 'subsink';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { UserType } from 'src/app/models/enums';
import { Router } from '@angular/router';

@Component({
  selector: 'app-proposal-details-page',
  templateUrl: './proposal-details-page.component.html',
  styleUrls: ['./proposal-details-page.component.scss'],
})
export class ProposalDetailsPageComponent implements OnDestroy, OnInit {
  constructor(
    private state: StateService,
    private api: LecturerApiService,
    private adminApi: AdminApiService,
    private router: Router
  ) {}
  public CodeFromInput: string = '';
  public subs: SubSink = new SubSink();
  public userType: UserType | null = null;
  public code: string | null = null;
  public details: ProjectProposalDetailsWithStatus | null = null;
  public student1: Student | undefined = undefined;
  public student2: Student | undefined = undefined;
  public lecturer: Lecturer | undefined = undefined;
  ngOnInit(): void {
    this.userType = this.state.connectedUser!.userType;
    this.details = this.state.selectedProposal;
    this.student1 = this.state.students!.find(
      (x) => x.id == this.details!.student1ID
    );
    this.student2 = this.state.students!.find(
      (x) => x.id == this.details!.student2ID
    );
    this.lecturer = this.state.lecturers!.find(
      (x) => x.id == this.details!.lecturerID
    );
    console.log(this.details);
    console.log(this.student1);
    console.log(this.student2);
    console.log(this.lecturer);
  }

  ngOnDestroy(): void {
    this.state.selectedProposal = null;
    this.subs.unsubscribe();
  }

  approve(id: number) {
    console.log('approve and delete proposal with id ', id);
    this.subs.sink = this.api
      .aproveProposal(this.details!.id)
      .subscribe((x) => {
        console.log('proposal was approved ? ', x);
        this.router.navigate(['home/proposals']);
      });
  }

  setCode() {
    this.code = this.CodeFromInput;
  }

  approveAdmin(id: number) {
    console.log(
      'approve and delete proposal with id ',
      id,
      'then create a project'
    );
    console.log(this.details!.id, this.code!);
    this.subs.sink = this.adminApi
      .aproveProposal(this.details!.id, this.code!)
      .subscribe((x) => {
        console.log('proposal was approved by admin ? ', x);
        this.router.navigate(['home/proposals']);
      });
  }

  deny(id: number) {
    console.log('deny and delete proposal with id ', id);
  }
}
