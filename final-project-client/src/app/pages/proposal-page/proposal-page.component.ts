import { StateService } from 'src/app/services/state.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-proposal-page',
  templateUrl: './proposal-page.component.html',
  styleUrls: ['./proposal-page.component.scss'],
})
export class ProposalPageComponent {
  constructor(protected state: StateService) {}
}
