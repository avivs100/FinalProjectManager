import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ProjectFull } from 'src/app/models/project-grade-models';

import { AdminApiService } from 'src/app/services/admin-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-admin-projects',
  templateUrl: './admin-projects.component.html',
  styleUrls: ['./admin-projects.component.scss'],
})
export class AdminProjectsComponent implements OnInit {
  public projects$: Observable<ProjectFull[]> = this.adminApi.getProjects();
  constructor(
    private adminApi: AdminApiService,
    private state: StateService,
    private router: Router
  ) {}
  ngOnInit(): void {
    this.projects$.subscribe((x) => console.log(x));
  }

  public selectedProject({ data }: { data: ProjectFull }) {
    this.state.project = data;
    this.router.navigate(['home/project']);
  }
}
