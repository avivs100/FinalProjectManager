import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './layout/home/home/home.component';
import { GradesComponent } from './pages/grades-page/grades-page.component';
import { LoginPageComponent } from './pages/login/login-page/login-page.component';
import { MessagesPageComponent } from './pages/messages-page/messages-page.component';
import { PremissionsPageComponent } from './pages/premissions-page/premissions-page.component';
import { ProjectsPageComponent } from './pages/projects/projects-page.component';
import { RegisterPageComponent } from './pages/register/register-page/register-page.component';
import { LecturerScheduleComponent } from './pages/schedule-page/lecturer-schedule/lecturer-schedule.component';
import { LecturerSubmissionsComponent } from './pages/submissions-page/lecturer-submissions/lecturer-submissions.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    children: [
      {
        path: 'messages',
        component: MessagesPageComponent,
      },
      {
        path: 'grades',
        component: GradesComponent,
      },
      {
        path: 'premissions',
        component: PremissionsPageComponent,
      },
      {
        path: 'projects',
        component: ProjectsPageComponent,
      },
      {
        path: 'schedule',
        component: LecturerScheduleComponent,
      },
      {
        path: 'submissions',
        component: LecturerSubmissionsComponent,
      },
    ],
  },
  {
    path: 'login',
    component: LoginPageComponent,
  },
  {
    path: 'register',
    component: RegisterPageComponent,
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
