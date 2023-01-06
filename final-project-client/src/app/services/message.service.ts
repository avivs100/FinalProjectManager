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
export class MessageServiceApi {
  readonly serverUrl = 'https://localhost:7114/api';
  constructor(private http: HttpClient) {}

  SendEmailToAllStudents(from: string, subject: string, message: string) {
    var details: MessageDetails = {
      from: from,
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailToAllStudents`,
      details
    );
  }

  SendEmailToAllLecturers(from: string, subject: string, message: string) {
    var details: MessageDetails = {
      from: from,
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailToAllLecturers`,
      details
    );
  }

  SendEmailToAllUsers(from: string, subject: string, message: string) {
    var details: MessageDetails = {
      from: from,
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailToAllUsers`,
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
      subject,
      message,
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
      subject,
      message,
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
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Admin/SendEmailTo2StudentsByProjectId${id}`,
      details
    );
  }

  SendEmailTo1StudentByLecturer(
    id: number,
    from: string,
    subject: string,
    message: string
  ) {
    var details: MessageDetails = {
      from: from,
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Lecturer/SendEmailTo1Lecturer${id}`,
      details
    );
  }

  SendEmailTo2StudentsByProjectIdByLectuer(
    id: number,
    from: string,
    subject: string,
    message: string
  ) {
    var details: MessageDetails = {
      from: from,
      subject,
      message,
    };
    return this.http.put<boolean>(
      `${this.serverUrl}/Lecturer/SendEmailTo2StudentsByProjectId${id}`,
      details
    );
  }
}
