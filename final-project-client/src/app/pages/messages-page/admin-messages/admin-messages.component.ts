import { AdminApiService } from './../../../services/admin-api.service';
import { StateService } from './../../../services/state.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';

import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { MessageServiceApi } from 'src/app/services/message.service';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';
import { messageFormData } from '../send-message-dialog/send-message-form/send-message-form.component';

@Component({
  providers: [DialogService],
  selector: 'app-admin-messages',
  templateUrl: './admin-messages.component.html',
  styleUrls: ['./admin-messages.component.scss'],
})
export class AdminMessagesComponent implements OnDestroy, OnInit {
  constructor(
    private dialog: DialogService,
    private messageService: MessageServiceApi,
    private state: StateService,
    private adminApi: AdminApiService
  ) {}

  ngOnInit(): void {
    console.log('david get all details');
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  public subs: SubSink = new SubSink();

  public openRegisterDialog() {
    const ref = this.dialog.open(SendMessageDialogComponent, {
      header: 'Message Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      console.log(formData);
    });
  }

  SendEmailToAllStudents(message: messageFormData) {
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllStudents(from, message.subject, message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailToAllLecturers(message: messageFormData) {
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllLecturers(from, message.subject, message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailToAllUsers(message: messageFormData) {
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllUsers(from, message.subject, message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailTo1Student(message: messageFormData) {
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Student(id, from, message.subject, message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailTo1Lecturer(message: messageFormData) {
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Lecturer(id, from, message.subject, message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailTo2StudentsByProjectId(message: messageFormData) {
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo2StudentsByProjectId(
        id,
        from,
        message.subject,
        message.message
      )
      .subscribe((x) => console.log(x));
  }
}
