import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface MessageDetails {
  from: string;
  subject: string;
  message: string;
}

@Injectable({
  providedIn: 'root',
})
export class MessageService {
  readonly serverUrl = 'https://localhost:7114/api';
  constructor(private http: HttpClient) {}

  SendEmailToAllStudents(from: string, subject: string, message: string) {
    var details: MessageDetails = {
      from: from,
      message: subject,
      subject: message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailToAllStudents`,
      details
    );
  }

  SendEmailTo1Student(
    id: number,
    from: string,
    subject: string,
    message: string
  ) {
    var details: MessageDetails = {
      from: from,
      message: subject,
      subject: message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailTo1Student${id}`,
      details
    );
  }

  SendEmailTo1Lecturer(
    id: number,
    from: string,
    subject: string,
    message: string
  ) {
    var details: MessageDetails = {
      from: from,
      message: subject,
      subject: message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailTo1Lecturer${id}`,
      details
    );
  }

  SendEmailTo2StudentsByProjectId(
    id: number,
    from: string,
    subject: string,
    message: string
  ) {
    var details: MessageDetails = {
      from: from,
      message: subject,
      subject: message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailTo2StudentsByProjectId${id}`,
      details
    );
  }
}
