import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/services/login-service.service';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent {
  constructor(
    private loginService: LoginServiceService,
    private router: Router
  ) {
    if (loginService.connerctedUser == null) {
      router.navigate(['/login']);
    }
  }
}
