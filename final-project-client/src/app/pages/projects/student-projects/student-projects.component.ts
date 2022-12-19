import { Component, Input } from '@angular/core';
import { ProjectFull, User } from 'src/app/models/modelsInterfaces';
import { StateService } from 'src/app/services/state.service';

@Component({
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent {
  @Input() public user: User | null = null;
  public project: ProjectFull | null = null;
  constructor(private state: StateService) {}
}
