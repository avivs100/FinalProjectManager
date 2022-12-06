<<<<<<< HEAD
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginServiceService } from 'src/app/services/login-service.service';
=======
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
>>>>>>> b9dc2fdc05fe00dadec6d1322f53235941ac3787

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
<<<<<<< HEAD
export class HomeComponent {
  constructor(
    private loginService: LoginServiceService,
    private router: Router
  ) {
    if (loginService.connerctedUser == null) {
      router.navigate(['/login']);
=======
export class HomeComponent implements OnInit {
  constructor(private loginService: LoginService, private router: Router) {}

  ngOnInit(): void {
    if (this.loginService.connectedUser == null) {
      this.router.navigate(['/login']);
>>>>>>> b9dc2fdc05fe00dadec6d1322f53235941ac3787
    }
  }
}
