import { StateService } from 'src/app/services/state.service';
import { Component, OnInit } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { SubSink } from 'subsink';

@Component({
  selector: 'app-lecturer-proposal',
  templateUrl: './lecturer-proposal.component.html',
  styleUrls: ['./lecturer-proposal.component.scss'],
})
export class LecturerProposalComponent implements OnInit {
  constructor(
    private state: StateService,
    private router: Router,
    private api: GeneralApiService
  ) {
    this.proposals = this.state.proposals!.filter(function (x) {
      return x.lecturerID == state.connectedUser!.id;
    });
    console.log(this.proposals);
  }
  ngOnInit(): void {}
  public proposals$: Observable<ProjectProposalDetailsWithStatus[]> =
    this.api.getProposals();
  public sub = new SubSink();
  public proposals: ProjectProposalDetailsWithStatus[] | null = null;

  goToProposalDetails(details: ProjectProposalDetailsWithStatus) {
    console.log('navigate to proposal details');
    this.state.selectedProposal = details;
    this.router.navigate(['home/proposal-details']);
  }
}
