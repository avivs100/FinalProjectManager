import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';

@Component({
  selector: 'app-proposal-list',
  templateUrl: './proposal-list.component.html',
  styleUrls: ['./proposal-list.component.scss'],
})
export class ProposalListComponent {
  @Input() proposals: ProjectProposalDetailsWithStatus[] | null = [];
  @Output()
  goToProposalDetails: EventEmitter<ProjectProposalDetailsWithStatus> =
    new EventEmitter<ProjectProposalDetailsWithStatus>();

  selectedProposal({ data }: { data: ProjectProposalDetailsWithStatus }) {
    console.log('da');
    this.goToProposalDetails.emit(data);
  }
}
