import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScheduleFull } from '../models/schedule-models';

@Injectable({
  providedIn: 'root',
})
export class SchduleApiService {
  readonly serverUrl = 'https://localhost:7114/api';
  constructor(private http: HttpClient) {}

  GetSchedule(): Observable<ScheduleFull> {
    return this.http.post<ScheduleFull>(
      `${this.serverUrl}/Schedule/GetSchedule`,
      null
    );
  }

  GenerateSchedule(): Observable<ScheduleFull> {
    return this.http.post<ScheduleFull>(
      `${this.serverUrl}/Schedule/GenerateSchedule`,
      null
    );
  }

  DeleteSchedule(): Observable<boolean> {
    return this.http.delete<boolean>(
      `${this.serverUrl}/Schedule/GenerateSchedule`
    );
  }

  RemoveLecturerFromSession(
    sessionId: number,
    lecturerId: number
  ): Observable<boolean> {
    return this.http.delete<boolean>(
      `${this.serverUrl}/Schedule/RemoveLecturerFromSession/${sessionId}/${lecturerId}`
    );
  }

  AddLecturerFromSession(
    sessionId: number,
    lecturerId: number
  ): Observable<boolean> {
    return this.http.post<boolean>(
      `${this.serverUrl}/Schedule/AddLecturerFromSession/${sessionId}/${lecturerId}`,
      null
    );
  }

  AddProjectFromSession(
    sessionId: number,
    projectId: number
  ): Observable<boolean> {
    return this.http.post<boolean>(
      `${this.serverUrl}/Schedule/AddProjectFromSession/${sessionId}/${projectId}`,
      null
    );
  }

  RemoveProjectFromSession(
    sessionId: number,
    projectId: number
  ): Observable<boolean> {
    return this.http.delete<boolean>(
      `${this.serverUrl}/Schedule/RemoveProjectFromSession/${sessionId}/${projectId}`
    );
  }
}
