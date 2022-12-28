import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ButtonModule } from 'primeng/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RippleModule } from 'primeng/ripple';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule } from 'primeng/calendar';
import { HomeComponent } from './layout/home/home/home.component';
import { StudentSidebarComponent } from './layout/sidebar/student-sidebar/student-sidebar.component';
import { ToolbarComponent } from './layout/toolbar/toolbar/toolbar.component';
import { LoginPageComponent } from './pages/login/login-page/login-page.component';
import { RegisterPageComponent } from './pages/register/register-page/register-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CheckboxModule } from 'primeng/checkbox';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { InputTextModule } from 'primeng/inputtext';
import { MenuModule } from 'primeng/menu';
import { MultiSelectModule } from 'primeng/multiselect';
import { FocusTrapModule } from 'primeng/focustrap';
import { TagModule } from 'primeng/tag';
import { ConfirmationService, MessageService } from 'primeng/api';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputNumberModule } from 'primeng/inputnumber';
import { PasswordModule } from 'primeng/password';
import { InputMaskModule } from 'primeng/inputmask';
import { KeyFilterModule } from 'primeng/keyfilter';
import { ToolbarModule } from 'primeng/toolbar';
import { CardModule } from 'primeng/card';

import { GradesComponent } from './pages/grades-page/grades-page.component';
import { LecturerSidebarComponent } from './layout/sidebar/lecturer-sidebar/lecturer-sidebar.component';
import { AdminSidebarComponent } from './layout/sidebar/admin-sidebar/admin-sidebar.component';

import { AdminGradesComponent } from './pages/grades-page/admin-grades/admin-grades.component';
import { LecturerGradesComponent } from './pages/grades-page/lecturer-grades/lecturer-grades.component';
import { StudentGradesComponent } from './pages/grades-page/student-grades/student-grades.component';
import { AdminProjectsComponent } from './pages/projects/admin-projects/admin-projects.component';
import { LecturerProjectsComponent } from './pages/projects/lecturer-projects/lecturer-projects.component';
import { PremissionsPageComponent } from './pages/premissions-page/premissions-page.component';
import { LecturerSubmissionsComponent } from './pages/submissions-page/lecturer-submissions/lecturer-submissions.component';
import { StudentSubmissionsComponent } from './pages/submissions-page/student-submissions/student-submissions.component';
import { AdminSubmissionsComponent } from './pages/submissions-page/admin-submissions/admin-submissions.component';
import { HttpClientModule } from '@angular/common/http';
import { LecturerScheduleComponent } from './pages/schedule-page/lecturer-schedule/lecturer-schedule.component';
import { StudentScheduleComponent } from './pages/schedule-page/student-schedule/student-schedule.component';
import { AdminScheduleComponent } from './pages/schedule-page/admin-schedule/admin-schedule.component';
import { SubmissionsComponent } from './pages/submissions-page/submissions-page.component';
import { ProjectsPageComponent } from './pages/projects/projects-page.component';
import { TableModule } from 'primeng/table';
import { LecturerMessagesComponent } from './pages/messages-page/lecturer-messages/lecturer-messages.component';
import { StudentMessagesComponent } from './pages/messages-page/student-messages/student-messages.component';
import { AdminMessagesComponent } from './pages/messages-page/admin-messages/admin-messages.component';
import { MessagesPageComponent } from './pages/messages-page/messages-page.component';
import { ScheduleComponent } from './pages/schedule-page/schedule-page.component';
import { ForgotPasswordPageComponent } from './pages/forgot-password-page/forgot-password-page.component';
import { WelcomeComponent } from './layout/welcome/welcome.component';
import { StudentProjectsComponent } from './pages/projects/student-projects/student-projects.component';
import { ProjectDetailsComponent } from './pages/projects/project-details/project-details.component';
import { AdminApiService } from './services/admin-api.service';
import { GeneralApiService } from './services/general-api.service';
import { LecturerApiService } from './services/lecturer-api.service';
import { LoginService } from './services/login-service.service';
import { StateService } from './services/state.service';
import { ToastModule } from 'primeng/toast';
import { ScheduleDetailsComponent } from './pages/schedule-page/schedule-details/schedule-details.component';
import { CreateScheduleComponent } from './pages/schedule-page/admin-schedule/create-schedule/create-schedule.component';
import { SelectScheduleDaysDialogComponent } from './pages/schedule-page/admin-schedule/select-schedule-days-dialog/select-schedule-days-dialog.component';
import { RegisterDialogComponent } from './pages/login/login-page/register-dialog/register-dialog.component';
import { RegisterFormComponent } from './pages/login/login-page/register-dialog/register-form/register-form.component';
import { LecturerAddConstraintsComponent } from './pages/schedule-page/lecturer-schedule/lecturer-add-constraints/lecturer-add-constraints.component';
import { SendMessageDialogComponent } from './pages/messages-page/send-message-dialog/send-message-dialog.component';
import { SendMessageFormComponent } from './pages/messages-page/send-message-dialog/send-message-form/send-message-form.component';
import { CreateProjectProposalDialogComponent } from './pages/projects/create-project-proposal-dialog/create-project-proposal-dialog.component';
import { CreateProjectProposalFormComponent } from './pages/projects/create-project-proposal-dialog/create-project-proposal-form/create-project-proposal-form.component';
//import { SelectScheduleDaysFormComponent } from './pages/schedule-page/admin-schedule/select-schedule-days-dialog/select-schedule-days-form/select-schedule-days-form.component';

@NgModule({
  declarations: [
    ScheduleComponent,
    AppComponent,
    HomeComponent,
    StudentSidebarComponent,
    ToolbarComponent,
    LoginPageComponent,
    RegisterPageComponent,
    StudentMessagesComponent,
    GradesComponent,
    LecturerSidebarComponent,
    AdminSidebarComponent,
    LecturerMessagesComponent,
    AdminMessagesComponent,
    MessagesPageComponent,
    AdminGradesComponent,
    LecturerGradesComponent,
    StudentGradesComponent,
    AdminProjectsComponent,
    LecturerProjectsComponent,
    PremissionsPageComponent,
    LecturerSubmissionsComponent,
    StudentSubmissionsComponent,
    AdminSubmissionsComponent,
    LecturerScheduleComponent,
    StudentScheduleComponent,
    AdminScheduleComponent,
    SubmissionsComponent,
    ProjectsPageComponent,
    ForgotPasswordPageComponent,
    WelcomeComponent,
    StudentProjectsComponent,
    ProjectDetailsComponent,
    ScheduleDetailsComponent,
    CreateScheduleComponent,
    SelectScheduleDaysDialogComponent,
    RegisterDialogComponent,
    RegisterFormComponent,
    LecturerAddConstraintsComponent,
    SendMessageDialogComponent,
    SendMessageFormComponent,
    CreateProjectProposalDialogComponent,
    CreateProjectProposalFormComponent,
  ],
  imports: [
    FocusTrapModule,
    ToastModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    ButtonModule,
    RippleModule,
    BrowserAnimationsModule,
    CalendarModule,
    FormsModule,
    ReactiveFormsModule,
    ToolbarModule,
    CardModule,
    MenuModule,
    DynamicDialogModule,
    InputTextModule,
    CheckboxModule,
    TagModule,
    MultiSelectModule,
    DropdownModule,
    InputTextareaModule,
    InputNumberModule,
    InputMaskModule,
    KeyFilterModule,
    PasswordModule,
    ToastModule,
    ConfirmDialogModule,
    TableModule,
  ],
  providers: [
    ConfirmationService,
    MessageService,
    AdminApiService,
    GeneralApiService,
    LecturerApiService,
    LoginService,
    StateService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
