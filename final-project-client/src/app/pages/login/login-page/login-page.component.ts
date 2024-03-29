import { Component, ComponentFactoryResolver } from '@angular/core';
import { waitForAsync } from '@angular/core/testing';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { DialogService } from 'primeng/dynamicdialog';
import { catchError, delay, filter, map, of } from 'rxjs';
import { GeneralApiService } from 'src/app/services/general-api.service';
import { LoginService } from 'src/app/services/login-service.service';
import { StateService } from 'src/app/services/state.service';
import { RegisterDialogComponent } from './register-dialog/register-dialog.component';

export interface loginFormData {
  id: number;
  password: string;
}

@Component({
  providers: [DialogService],
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    private state: StateService,
    private dialog: DialogService,
    private genApi: GeneralApiService,
    private messageService: MessageService
  ) {}
  public form: FormGroup = this.fb.group({
    id: [, Validators.required],
    password: ['', Validators.required],
  });

  onSubmit(formData: loginFormData) {
    this.loginService.login(formData.id, formData.password);
  }

  public moveToRegisterPage(): void {
    this.router.navigate(['register']);
  }

  public openRegisterDialog() {
    const ref = this.dialog.open(RegisterDialogComponent, {
      header: 'Register Form',
      width: '800px',
      height: '750px',
    });
    ref.onClose.pipe(filter(Boolean)).subscribe((formData) => {
      this.genApi
        .register(formData)
        .pipe(
          catchError((err) => of(this.showToast(false)).pipe(map(() => false)))
        )
        .subscribe((x) => this.showToast(x));
    });
  }

  onReject() {}

  showToast(x: boolean) {
    this.messageService.clear();
    if (x == true) {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail:
          'Your Account added with success, if you a lecturer you need to wait for admin aprove',
      });
    } else {
      this.messageService.add({
        severity: 'error',
        summary: 'Error',
        detail: 'Error, you account creation fail',
      });
    }
  }
}
