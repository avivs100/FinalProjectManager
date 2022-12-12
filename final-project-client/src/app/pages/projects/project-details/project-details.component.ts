import { Component, Input } from '@angular/core';
import { Project, ProjectType } from 'src/app/models/modelsInterfaces';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.scss'],
})
export class ProjectDetailsComponent {
  @Input() public project: Project | null = null;
  public ProjectType: ProjectType | undefined;
}
