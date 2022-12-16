import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: [],
})
export class RegisterFormComponent {
  @Output() public save = new EventEmitter<RegisterFormData>();

  constructor(private fb: FormBuilder, private loginService: LoginService) {}

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
  }
}
