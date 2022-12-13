import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class GeneralApiService {
  readonly serverUrl = 'https://localhost:44337/api';

  constructor(private http: HttpClient) {}
}
