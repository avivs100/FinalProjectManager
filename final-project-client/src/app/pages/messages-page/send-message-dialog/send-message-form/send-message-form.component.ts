import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from 'src/app/services/login-service.service';

export interface messageFormData {
  message: string;
  subject: string;
}
@Component({
  selector: 'app-send-message-form',
  templateUrl: './send-message-form.component.html',
  styleUrls: ['./send-message-form.component.scss'],
})
export class SendMessageFormComponent {
  @Output() public save = new EventEmitter<messageFormData>();

  constructor(private fb: FormBuilder) {}

  public form: FormGroup = this.fb.group({
    message: ['', [Validators.required, Validators.minLength(30)]],
    subject: ['', [Validators.required, Validators.minLength(5)]],
  });

  onSubmit(formData: messageFormData) {
    this.save.emit(formData);
  }
}
