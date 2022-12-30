import { StateService } from 'src/app/services/state.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';
import { Student, Lecturer } from 'src/app/models/users-models';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-proposal-details-page',
  templateUrl: './proposal-details-page.component.html',
  styleUrls: ['./proposal-details-page.component.scss'],
})
export class ProposalDetailsPageComponent implements OnDestroy, OnInit {
  constructor(private state: StateService, private api: LecturerApiService) {}

  public subs: SubSink = new SubSink();

  public details: ProjectProposalDetailsWithStatus | null = null;
  public student1: Student | undefined = undefined;
  public student2: Student | undefined = undefined;
  public lecturer: Lecturer | undefined = undefined;
  ngOnInit(): void {
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
      .subscribe((x) => console.log('proposal was approved ? ', x));
  }

  deny(id: number) {
    console.log('deny and delete proposal with id ', id);
  }
}
