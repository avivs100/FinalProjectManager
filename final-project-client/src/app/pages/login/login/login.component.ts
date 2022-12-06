import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login-service.service';

export interface loginFormData {
  id: number;
  password: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
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
    console.log(formData);
    var success = this.loginService.login(formData.id, formData.password);
    if (success == true) {
      this.router.navigate(['']);
    } else {
      console.log('error');
    }
  }

  public moveToRegisterPage(): void {
    console.log('david');
    this.router.navigate(['register']);
  }
}
