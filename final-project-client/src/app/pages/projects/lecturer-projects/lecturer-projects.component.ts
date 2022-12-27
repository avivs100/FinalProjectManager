import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectFull } from 'src/app/models/project-grade-models';

import { LecturerApiService } from 'src/app/services/lecturer-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-lecturer-projects',
  templateUrl: './lecturer-projects.component.html',
  styleUrls: ['./lecturer-projects.component.scss'],
})
export class LecturerProjectsComponent implements OnInit {
  constructor(
    private api: LecturerApiService,
    private state: StateService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.projects = this.state.lecturerProjects;
  }
  public projects: ProjectFull[] | null = null;

  public selectedProject({ data }: { data: ProjectFull }) {
    this.state.project = data;
    this.router.navigate(['home/project']);
  }
}
