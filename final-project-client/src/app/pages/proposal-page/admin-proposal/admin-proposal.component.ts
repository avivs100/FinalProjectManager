import { StateService } from 'src/app/services/state.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';
import { Router } from '@angular/router';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { GeneralApiService } from 'src/app/services/general-api.service';

@Component({
  selector: 'app-admin-proposal',
  templateUrl: './admin-proposal.component.html',
  styleUrls: ['./admin-proposal.component.scss'],
})
export class AdminProposalComponent implements OnDestroy, OnInit {
  constructor(
    protected state: StateService,
    private router: Router,
    private adminApi: AdminApiService,
    private api: GeneralApiService
  ) {}

  public proposals$ = this.api.getProposals();
  public proposalsAfterAprove$ = this.adminApi.getProposalsAfterAprove();

  ngOnInit(): void {}
  ngOnDestroy(): void {}

  goToProposalDetails(details: ProjectProposalDetailsWithStatus) {
    console.log('navigate to proposal details');
    this.state.selectedProposal = details;
    this.router.navigate(['home/proposal-details']);
  }
}
