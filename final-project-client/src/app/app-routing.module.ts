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
import { ScheduleComponent } from './pages/schedule-page/schedule-page.component';
import { LecturerSubmissionsComponent } from './pages/submissions-page/lecturer-submissions/lecturer-submissions.component';
import { SubmissionsComponent } from './pages/submissions-page/submissions-page.component';

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
        component: ScheduleComponent,
      },
      {
        path: 'submissions',
        component: SubmissionsComponent,
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
