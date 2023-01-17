import { AdminApiService } from './../../services/admin-api.service';
import { Component, OnInit } from '@angular/core';
import { SubSink } from 'subsink';
import { premission } from 'src/app/models/users-models';
import { StateService } from 'src/app/services/state.service';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Component({
  templateUrl: './premissions-page.component.html',
  styleUrls: ['./premissions-page.component.scss'],
})
export class PremissionsPageComponent implements OnInit {
  constructor(
    private api: AdminApiService,
    private state: StateService,
    private messageService: MessageService
  ) {}
  public subs: SubSink = new SubSink();
  public premissions$ = this.api.getPremissions();

  ngOnInit(): void {}

  aproveLecturerPremission(id: number) {
    this.subs.sink = this.api.aproveLecturerPremission(id).subscribe((x) => {
      console.log('aproved lecturer with id ', id, x);
      this.showToast(x, 'Approve');
      this.premissions$ = this.api.getPremissions();
    });
  }

  deleteLecturerPremission(id: number) {
    this.subs.sink = this.api.deleteLecturerPremission(id).subscribe((x) => {
      console.log('deleted lecturer premission with id ', id, x);
      this.showToast(x, 'Deny');
      this.premissions$ = this.api.getPremissions();
    });
  }

  showToast(x: boolean, msg: string) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Your ' + msg + ' saved successfully',
      });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error, faild to ' + msg + ' to the server',
      });
    }
  }
}
