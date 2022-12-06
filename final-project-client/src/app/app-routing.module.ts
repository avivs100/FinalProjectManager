import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './layout/home/home/home.component';

import { GradesComponent } from './pages/grades/grades.component';
import { LoginComponent } from './pages/login/login/login.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { RegisterComponent } from './pages/register/register/register.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    children: [
      {
        path: 'messages',
        component: MessagesComponent,
      },
      {
        path: 'grades',
        component: GradesComponent,
        children: [],
      },
    ],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
