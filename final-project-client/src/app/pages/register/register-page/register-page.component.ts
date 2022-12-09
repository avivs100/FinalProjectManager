import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login-service.service';

export interface RegisterFormData {
  id: number;
  password: string;
  email: String;
  firstName: string;
  lastName: string;
  lecturer: boolean;
}

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.scss'],
})
export class RegisterPageComponent {
  public varifyPass: string = '';
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginService: LoginService
  ) {}
  public form: FormGroup = this.fb.group({
    id: [, Validators.required],
    password: ['', Validators.required],

    email: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    lecturer: [false],
  });

  onSubmit(formData: RegisterFormData) {
    console.log(formData);
  }

  moveToLoginPage() {
    console.log('david');
    this.router.navigate(['login']);
  }
}
