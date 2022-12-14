import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login-service.service';

export interface loginFormData {
  id: number;
  password: string;
}

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss'],
})
export class LoginPageComponent {
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginService: LoginService
  ) {}
  public form: FormGroup = this.fb.group({
    id: [, Validators.required],
    password: ['', Validators.required],
  });

  onSubmit(formData: loginFormData) {
    if (this.loginService.login(formData.id, formData.password)) {
      this.router.navigate(['/home']);
      console.log('submitform');
    } else {
      console.log('error');
    }
  }

  public moveToRegisterPage(): void {
    console.log('david');
    this.router.navigate(['register']);
  }
}
