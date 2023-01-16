import { Component, Input, OnChanges, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Subscription } from 'rxjs';
import { ProjectFull } from 'src/app/models/project-grade-models';
import { ProjectInSession, Session } from 'src/app/models/schedule-models';
import { Lecturer } from 'src/app/models/users-models';
import { SchduleApiService } from 'src/app/services/schdule-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-session-details',
  templateUrl: './session-details.component.html',
  styleUrls: ['./session-details.component.scss'],
})
export class SessionDetailsComponent implements OnChanges, OnDestroy {
  constructor(
    protected state: StateService,
    private router: Router,
    private messageService: MessageService,
    private api: SchduleApiService
  ) {}
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
  ngOnInit(): void {}

  @Input() session: Session | null = null;
  @Input() number: Number | null = null;
  public time: string = '';
  public itsMySession: boolean = false;
  @Input() isEdit: boolean = true;
  public sub: Subscription = new Subscription();

  ngOnChanges(): void {
    console.log('eee', this.session);
    switch (this.number) {
      case 1:
        this.time = '08:00 - 10:00';
        break;
      case 2:
        this.time = '10:00 - 12:00';
        break;
      case 3:
        this.time = '12:00 - 14:00';
        break;
      case 4:
        this.time = '14:00 - 16:00';
        break;
      case 5:
        this.time = '16:00 - 18:00';
        break;
      default:
        break;
    }
    if (
      this.session!.lecturer2?.id == this.state.connectedUser!.id ||
      this.session!.lecturer3?.id == this.state.connectedUser!.id ||
      this.session!.responsibleLecturer?.id == this.state.connectedUser!.id
    ) {
      this.itsMySession = true;
    }
    this.session!.projects.forEach((x) => {
      if (
        x.projectFull.student1.id == this.state.connectedUser!.id ||
        x.projectFull!.student2.id == this.state.connectedUser!.id
      ) {
        this.itsMySession = true;
      }
    });
  }
  manualEdit(session: Session) {
    this.state.session = session;
    console.log(session);
    this.router.navigate(['home/manual-edit']);
  }

  deleteProjFromSession(proj: ProjectFull) {
    this.itsMySession = false;
    this.session!.projects = this.session!.projects.filter(function (project) {
      return project.projectFull.projectId !== proj.projectId;
    });
  }

  removeLecturer1() {
    this.itsMySession = false;
    this.session!.responsibleLecturer = null;
  }

  removeLecturer2() {
    this.itsMySession = false;
    this.session!.lecturer2 = null;
  }

  removeLecturer3() {
    this.itsMySession = false;
    this.session!.lecturer3 = null;
  }

  addLecturer1({ value }: { value: Lecturer }) {
    console.log(value, 1);
    this.session!.responsibleLecturer = value;
  }
  addLecturer2({ value }: { value: Lecturer }) {
    console.log(value, 2);
    this.session!.lecturer2 = value;
  }
  addLecturer3({ value }: { value: Lecturer }) {
    console.log(value, 3);
    this.session!.lecturer3 = value;
  }

  saveSessionToDb() {
    this.sub.add(
      this.api.updateSession(this.session!).subscribe((x) => {
        this.showToast(x);
        this.router.navigate(['/home/schedule-details']);
      })
    );
  }

  addProject({ value }: { value: ProjectFull }) {
    if (this.session!.projects.length >= 6) {
      this.showToast(false);
      return;
    }
    var projectForSession: ProjectInSession = {
      order: 1,
      projectFull: value,
    };
    console.log(value);
    this.session!.projects.push(projectForSession);
  }

  showToast(x: boolean) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Session Updated',
      });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error, Session not Updated',
      });
    }
  }
}
