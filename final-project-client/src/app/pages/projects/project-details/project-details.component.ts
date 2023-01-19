import { Component, Input } from '@angular/core';
import { ProjectType } from 'src/app/models/enums';
import { ProjectFull } from 'src/app/models/project-grade-models';

import { StateService } from 'src/app/services/state.service';
import { StudentApiService } from 'src/app/services/student-api.service';

@Component({
  selector: 'app-project-details',
  templateUrl: './project-details.component.html',
  styleUrls: ['./project-details.component.scss'],
})
export class ProjectDetailsComponent {
  public ProjectType: ProjectType | undefined;
  public project: ProjectFull | null = this.state.project;
  public userType = this.state.connectedUser!.userType;
  constructor(private state: StateService, private api: StudentApiService) {}
  public newName: string = this.state.project!.projectName;

  editProjectNameClick() {
    console.log('edit project name to ', this.newName);
  }
}
