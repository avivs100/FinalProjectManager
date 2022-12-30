import { StateService } from 'src/app/services/state.service';
import { Component } from '@angular/core';
import { ProjectProposalDetailsWithStatus } from 'src/app/models/project-grade-models';

@Component({
  selector: 'app-lecturer-proposal',
  templateUrl: './lecturer-proposal.component.html',
  styleUrls: ['./lecturer-proposal.component.scss'],
})
export class LecturerProposalComponent {
  constructor(private state: StateService) {
    this.proposals = this.state.proposals!.filter(function (x) {
      return x.lecturerID == state.connectedUser!.id;
    });
    console.log(this.proposals);
  }

  public proposals: ProjectProposalDetailsWithStatus[] | null = null;
}
