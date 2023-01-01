import { Component, OnDestroy, OnInit } from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { filter } from 'rxjs';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { MessageServiceApi } from 'src/app/services/message.service';
import { StateService } from 'src/app/services/state.service';
import { SubSink } from 'subsink';
import { MessageType } from '../admin-messages/admin-messages.component';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';
import { messageFormData } from '../send-message-dialog/send-message-form/send-message-form.component';

export enum MessageTypeForLecturer {
  Student,
  Project,
  Admin,
}

@Component({
  providers: [DialogService],
  selector: 'app-lecturer-messages',
  templateUrl: './lecturer-messages.component.html',
  styleUrls: ['./lecturer-messages.component.scss'],
})
export class LecturerMessagesComponent implements OnDestroy, OnInit {
  constructor(
    private dialog: DialogService,
    private messageService: MessageServiceApi,
    public state: StateService,
    private lecturerApi: LecturerApiService
  ) {}
  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  ngOnInit(): void {}

  public subs: SubSink = new SubSink();
  public message: messageFormData | null = null;

  public idOfProjectSend: number | null = null;
  public idOfStudentSend: number | null = null;
  public idOfAdminSend: number | null = null;

  public messageTo1Student: messageFormData | null = null; //0
  public messageTo1Project: messageFormData | null = null; //1
  public messageTo1Admin: messageFormData | null = null; //2

  public openMessageDialog(type: MessageTypeForLecturer) {
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
          this.messageTo1Project = this.message;
          break;
        case 2:
          this.messageTo1Admin = this.message;
          break;
        default:
          break;
      }
    });
  }

  createMessage(type: MessageTypeForLecturer) {
    this.openMessageDialog(type);
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
        console.log(x);
        this.messageTo1Student = null;
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
        console.log(x);
        this.messageTo1Project = null;
        this.message = null;
      });
  }

  SendEmailTo1Admin() {
    console.log('send message to 1 admin', this.messageTo1Admin);

    this.messageTo1Admin = null;
    this.message = null;
    // if (this.messageTo1Project == null) return;

    // var from =
    //   this.state.connectedUser!.firstName +
    //   ' ' +
    //   this.state.connectedUser!.lastName;
    // this.subs.sink = this.messageService
    //   .SendEmailTo2StudentsByProjectId(
    //     this.idOfProjectSend!,
    //     from,
    //     this.messageTo1Project.subject,
    //     this.messageTo1Project.message
    //   )
    //   .subscribe((x) => {
    //     console.log(x);
    //     this.messageTo1Project = null;
    //     this.message = null;
    //   });
  }
}
