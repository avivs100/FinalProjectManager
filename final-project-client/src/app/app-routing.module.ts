import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './layout/home/home/home.component';
<<<<<<< HEAD
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
=======
import { GradesComponent } from './pages/grades/grades.component';
import { LoginComponent } from './pages/login/login/login.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { RegisterComponent } from './pages/register/register/register.component';
>>>>>>> b9dc2fdc05fe00dadec6d1322f53235941ac3787

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
    path: '**',
    component: HomeComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
<<<<<<< HEAD
  },
  {
    path: 'register',
    component: RegisterComponent,
=======
    children: [],
>>>>>>> b9dc2fdc05fe00dadec6d1322f53235941ac3787
  },
  {
    path: 'register',
    component: RegisterComponent,
    children: [],
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
