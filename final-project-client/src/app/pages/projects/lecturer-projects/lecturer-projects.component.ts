import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectFull, User } from 'src/app/models/modelsInterfaces';
import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-lecturer-projects',
  templateUrl: './lecturer-projects.component.html',
  styleUrls: ['./lecturer-projects.component.scss'],
})
export class LecturerProjectsComponent {
  //public projects: ProjectFull[] = [];

  constructor(
    private api: LecturerApiService,
    private state: StateService,
    private router: Router
  ) {}
  public projects$: Observable<ProjectFull[]> = this.api.getLecturerProjects(
    this.state.connectedUser!.id
  );

  public selectedProject({ data }: { data: ProjectFull }) {
    this.state.project = data;
    this.router.navigate(['home/project']);
  }
}
