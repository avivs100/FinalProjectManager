import { AdminApiService } from './../../../services/admin-api.service';
import { StateService } from './../../../services/state.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';

import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { MessageServiceApi } from 'src/app/services/message.service';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';
import { messageFormData } from '../send-message-dialog/send-message-form/send-message-form.component';
import { MessageService } from 'primeng/api';

export enum MessageType {
  Student,
  Lecturer,
  Project,
  AllStudents,
  AllUsers,
  AllLecturers,
}

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
    private toastMessageService: MessageService,
    public state: StateService,
    private adminApi: AdminApiService
  ) {}
  ngOnInit(): void {
    // console.log('david get all details');
  }
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  public subs: SubSink = new SubSink();
  public message: messageFormData | null = null;

  public messageTo1Student: messageFormData | null = null; //0
  public messageTo1Lecturer: messageFormData | null = null; //1
  public messageTo1Project: messageFormData | null = null; //2
  public messageToAllStudents: messageFormData | null = null; //3
  public messageToAllUsers: messageFormData | null = null; //4
  public messageToAllLecturers: messageFormData | null = null; //5

  public idOfLecturerSend: number | null = null;
  public idOfProjectSend: number | null = null;
  public idOfStudentSend: number | null = null;

  public openMessageDialog(type: MessageType) {
    const ref = this.dialog.open(SendMessageDialogComponent, {
      header: 'Message Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      this.message = formData;
      switch (type) {
        case 0:
          this.messageTo1Student = this.message;
          break;
        case 1:
          this.messageTo1Lecturer = this.message;
          break;
        case 2:
          this.messageTo1Project = this.message;
          break;
        case 3:
          this.messageToAllStudents = this.message;
          break;
        case 4:
          this.messageToAllUsers = this.message;
          break;
        case 5:
          this.messageToAllLecturers = this.message;
          break;
        default:
          break;
      }
    });
  }

  createMessage(type: MessageType) {
    this.openMessageDialog(type);
  }

  SendEmailToAllStudents() {
    if (this.messageToAllStudents == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllStudents(
        from,
        this.messageToAllStudents.subject,
        this.messageToAllStudents.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageToAllStudents = null;
        this.message = null;
      });
  }

  SendEmailToAllLecturers() {
    if (this.messageToAllLecturers == null) return;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllLecturers(
        from,
        this.messageToAllLecturers.subject,
        this.messageToAllLecturers.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageToAllLecturers = null;
        this.message = null;
      });
  }

  SendEmailToAllUsers() {
    if (this.messageToAllUsers == null) return;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllUsers(
        from,
        this.messageToAllUsers.subject,
        this.messageToAllUsers.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageToAllUsers = null;
        this.message = null;
      });
  }

  SendEmailTo1Student() {
    if (this.messageTo1Student == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Student(
        this.idOfStudentSend!,
        from,
        this.messageTo1Student.subject,
        this.messageTo1Student.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageTo1Student = null;
        this.message = null;
      });
  }

  SendEmailTo1Lecturer() {
    if (this.messageTo1Lecturer == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Lecturer(
        this.idOfLecturerSend!,
        from,
        this.messageTo1Lecturer.subject,
        this.messageTo1Lecturer.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageTo1Lecturer = null;
        this.message = null;
      });
  }

  SendEmailTo2StudentsByProjectId() {
    if (this.messageTo1Project == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo2StudentsByProjectId(
        this.idOfProjectSend!,
        from,
        this.messageTo1Project.subject,
        this.messageTo1Project.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageTo1Project = null;
        this.message = null;
      });
  }

  showToast(x: boolean) {
    this.toastMessageService.clear();
    if (x == true) {
      this.toastMessageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Your Massege Sent Successfully',
      });
    } else {
      this.toastMessageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error, faild to send the message',
      });
    }
  }
}
