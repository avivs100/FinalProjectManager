import { AdminApiService } from './../../../services/admin-api.service';
import { StateService } from './../../../services/state.service';
import { SubSink } from 'subsink';
import { Component, OnDestroy, OnInit } from '@angular/core';

import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { MessageServiceApi } from 'src/app/services/message.service';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';
import { messageFormData } from '../send-message-dialog/send-message-form/send-message-form.component';

export enum MessageType{
  Student,Lecturer,Project,AllStudents,AllUsers,AllLecturers
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
    public state: StateService,
    private adminApi: AdminApiService
  ) {
    var lectuerers = this.state.lecturers;
    var projects = this.state.projects;
    var students = this.state.students;
  }
  ngOnInit(): void {
    console.log('david get all details');
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

  public openRegisterDialog(type:) {
    const ref = this.dialog.open(SendMessageDialogComponent, {
      header: 'Message Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      this.message = formData;
    });
  }

  createMessage() {
    this.openRegisterDialog();
  }

  SendEmailToAllStudents() {
    if (this.message == null) return;
    
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllStudents(from, this.message.subject, this.message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailToAllLecturers() {
    if (this.message == null) return;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllLecturers(from, this.message.subject, this.message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailToAllUsers() {
    console.log(this.message);
    if (this.message == null) return;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailToAllUsers(from, this.message.subject, this.message.message)
      .subscribe((x) => {
        console.log(x);
        this.message = null;
      });
  }

  SendEmailTo1Student() {
    if (this.message == null) return;
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Student(id, from, this.message.subject, this.message.message)
      .subscribe((x) => console.log(x));
  }

  SendEmailTo1Lecturer() {
    if (this.message == null) return;
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Lecturer(
        id,
        from,
        this.message.subject,
        this.message.message
      )
      .subscribe((x) => console.log(x));
  }

  SendEmailTo2StudentsByProjectId() {
    if (this.message == null) return;
    var id = 1;
    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo2StudentsByProjectId(
        id,
        from,
        this.message.subject,
        this.message.message
      )
      .subscribe((x) => console.log(x));
  }
}
