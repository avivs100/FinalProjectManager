import { Injectable } from '@angular/core';
import { DataProvaiderService } from './data-provaider.service';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(data: DataProvaiderService) {}
}
