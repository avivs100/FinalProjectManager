import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ProjectFull } from 'src/app/models/project-grade-models';

import { AdminApiService } from 'src/app/services/admin-api.service';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-admin-projects',
  templateUrl: './admin-projects.component.html',
  styleUrls: ['./admin-projects.component.scss'],
})
export class AdminProjectsComponent implements OnInit, OnDestroy {
  constructor(
    private adminApi: AdminApiService,
    private state: StateService,
    private router: Router
  ) {}
  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public projects$ = this.adminApi.getProjects();
  public sub = new Subscription();

  ngOnInit(): void {
    this.sub.add(this.projects$.subscribe((x) => console.log(x)));
  }

  public deleteProject(id: number) {
    this.sub.add(
      this.adminApi
        .deleteProject(id)
        .subscribe((_) => (this.projects$ = this.adminApi.getProjects()))
    );
    this.projects$ = this.adminApi.getProjects();
  }

  public selectedProject({ data }: { data: ProjectFull }) {
    this.state.project = data;
    this.router.navigate(['home/project']);
  }
}
