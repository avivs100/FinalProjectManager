import { Component, Input } from '@angular/core';
import { ProjectFull, ProjectType } from 'src/app/models/modelsInterfaces';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.scss'],
})
export class ProjectDetailsComponent {
  @Input() public project: ProjectFull | null = null;
  public ProjectType: ProjectType | undefined;
}
