import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-submissions',
  templateUrl: './student-submissions.component.html',
  styleUrls: ['./student-submissions.component.scss'],
})
export class StudentSubmissionsComponent {
  public gitHubForPart1: string = '';
  activeIndex1: number = 0;

  submitPart1() {
    console.log(this.gitHubForPart1);
  }

  constructor(private messageService: MessageService) {}
  uploadedFiles: any[] = [];

  onUpload(event: any) {
    for (let file of event.files) {
      this.uploadedFiles.push(file);
    }

    this.messageService.add({
      severity: 'info',
      summary: 'File Uploaded',
      detail: '',
    });
  }
}
