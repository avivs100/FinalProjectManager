import { Injectable, OnInit } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { GeneralApiService } from './general-api.service';
import { StateService } from './state.service';
import { SubSink } from 'subsink';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class LoginService implements OnInit {
  constructor(
    private generalApi: GeneralApiService,
    private state: StateService,
    private router: Router,
    private messageService: MessageService
  ) {}
  public ob$: Observable<any> | undefined;
  public type: number | undefined;
  private readonly subs: SubSink = new SubSink();

  ngOnInit(): void {}

  public login(id: number, pass: string) {
    this.generalApi
      .login(id, pass)
      .pipe(
        catchError((err) => {
          return of(
            this.showError(
              false,
              'Error, The username (id) or password is incorrect'
            )
          );
        })
      )
      .subscribe((x) => {
        if (x === 0) {
          this.generalApi
            .getAdmin(id)
            .pipe(
              tap((admin) => (this.state.connectedUser = admin)),
              catchError((err) => {
                return of(
                  this.showError(false, 'Error, cant find admin with id: ' + id)
                );
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 1) {
          this.generalApi
            .getStudent(id)
            .pipe(
              tap((student) => (this.state.connectedUser = student)),
              catchError((err) => {
                return of(
                  this.showError(
                    false,
                    'Error, cant find student with id: ' + id
                  )
                );
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 2) {
          this.generalApi
            .getLecturer(id)
            .pipe(
              tap((lecturer) => (this.state.connectedUser = lecturer)),
              catchError((err) => {
                return of(
                  this.showError(
                    false,
                    'Error, cant find lecturer with id: ' + id
                  )
                );
              })
            )
            .subscribe(() => this.router.navigate(['/home']));
        }
        if (x === 3) {
          this.showError(false, 'The username (id) or password is incorrect');
        }
      });
  }

  showError(x: boolean, str: string) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: str,
      });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: str,
      });
    }
  }
}
