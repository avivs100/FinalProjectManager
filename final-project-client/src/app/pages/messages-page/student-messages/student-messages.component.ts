import { Component, OnDestroy, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { filter, Observable } from 'rxjs';
import { Admin } from 'src/app/models/users-models';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { MessageServiceApi } from 'src/app/services/message.service';
import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';
import { SubSink } from 'subsink';
import { SendMessageDialogComponent } from '../send-message-dialog/send-message-dialog.component';
import { messageFormData } from '../send-message-dialog/send-message-form/send-message-form.component';

export enum MessageTypeForLecturer {
  lecturer,
  Project,
  Admin,
}

@Component({
  providers: [DialogService],
  selector: 'app-student-messages',
  templateUrl: './student-messages.component.html',
  styleUrls: ['./student-messages.component.scss'],
})
export class StudentMessagesComponent implements OnDestroy, OnInit {
  public subs: SubSink = new SubSink();
  public message: messageFormData | null = null;

  public idOfProjectSend: number | null = null;
  public idOfAdminSend: number | null = null;
  public idOfLecturerSend: number | null = null;

  constructor(
    private dialog: DialogService,
    private messageService: MessageServiceApi,
    public state: StateService,
    private genApi: GeneralApiService,
    private toastMessageService: MessageService,
    private lecApi: LecturerApiService
  ) {}

  ngOnDestroy(): void {
    this.subs.unsubscribe();
  }
  ngOnInit(): void {
    this.idOfProjectSend = this.state.project!.projectId;
    this.idOfLecturerSend = this.state.project!.lecturer.id;
  }

  public admins$: Observable<Admin[]> = this.genApi.getAdmins();

  public messageTo1lecturer: messageFormData | null = null; //0
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
          this.messageTo1lecturer = this.message;
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

  SendEmailTo1Admin() {
    if (this.messageTo1Admin == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Admin(
        this.idOfAdminSend!,
        from,
        this.messageTo1Admin.subject,
        this.messageTo1Admin.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageTo1Admin = null;
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

  SendEmailTo1Lecturer() {
    if (this.messageTo1lecturer == null) return;

    var from =
      this.state.connectedUser!.firstName +
      ' ' +
      this.state.connectedUser!.lastName;
    this.subs.sink = this.messageService
      .SendEmailTo1Lecturer(
        this.idOfLecturerSend!,
        from,
        this.messageTo1lecturer.subject,
        this.messageTo1lecturer.message
      )
      .subscribe((x) => {
        this.showToast(x);
        this.messageTo1lecturer = null;
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
