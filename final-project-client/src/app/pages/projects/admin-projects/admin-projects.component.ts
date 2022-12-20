import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ProjectFull } from 'src/app/models/modelsInterfaces';
import { AdminApiService } from 'src/app/services/admin-api.service';

@Component({
  selector: 'app-admin-projects',
  templateUrl: './admin-projects.component.html',
  styleUrls: ['./admin-projects.component.scss'],
})
export class AdminProjectsComponent implements OnInit {
  public projects$: Observable<ProjectFull[]> = this.adminApi.getProjects();
  constructor(private adminApi: AdminApiService) {}
  ngOnInit(): void {
    this.projects$.subscribe((x) => console.log(x));
  }

  public selectedProject({ data }: { data: ProjectFull }) {
    console.log(data);
  }
}
