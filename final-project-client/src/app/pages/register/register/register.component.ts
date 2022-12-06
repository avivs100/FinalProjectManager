import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/services/login-service.service';

export interface RegisterFormData {
  id: number;
  password: string;
  email: String;
  firstName: string;
  lastName: string;
  lecturer: boolean;
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  public varifyPass: string = '';
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private loginService: LoginServiceService
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
