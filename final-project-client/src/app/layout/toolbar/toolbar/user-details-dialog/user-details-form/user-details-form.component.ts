import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Admin, Lecturer, Student } from 'src/app/models/users-models';
import { RegisterFormData } from 'src/app/pages/register/register-page/register-page.component';
import { StateService } from 'src/app/services/state.service';

export interface userDetailsFormData {
  id: number;
  password: string;
  email: String;
  firstName: string;
  lastName: string;
}

@Component({
  selector: 'app-user-details-form',
  templateUrl: './user-details-form.component.html',
})
export class UserDetailsFormComponent implements OnInit {
  @Output() public save = new EventEmitter<userDetailsFormData>();

  constructor(private fb: FormBuilder, private state: StateService) {}
  ngOnInit(): void {
    this.user = this.state.connectedUser;
    this.form.patchValue({
      password: this.user!.password,
      email: this.user!.email,
      firstName: this.user!.firstName,
      lastName: this.user!.lastName,
    });
  }
  public user: Admin | Student | Lecturer | null = null;
  public form: FormGroup = this.fb.group({
    password: ['', Validators.required],
    email: ['', Validators.required],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
  });

  onSubmit(formData: RegisterFormData) {
    this.save.emit(formData);
  }
}
