import { StateService } from './../../../services/state.service';
import { Component } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';
import { ProposalFormData } from './create-project-proposal-form/create-project-proposal-form.component';

@Component({
  selector: 'app-create-project-proposal-dialog',
  templateUrl: './create-project-proposal-dialog.component.html',
})
export class CreateProjectProposalDialogComponent {
  constructor(private ref: DynamicDialogRef, protected state: StateService) {}

  public save(formData: ProposalFormData): void {
    this.ref.close(formData);
  }
}
