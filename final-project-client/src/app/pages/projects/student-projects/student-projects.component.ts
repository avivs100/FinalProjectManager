import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Project, User } from 'src/app/models/modelsInterfaces';
import { DataProvaiderService } from 'src/app/services/data-provaider.service';

@Component({
  selector: 'app-student-projects',
  templateUrl: './student-projects.component.html',
  styleUrls: ['./student-projects.component.scss'],
})
export class StudentProjectsComponent implements OnChanges {
  @Input() public user: User | null = null;
  public project: Project | null = null;
  constructor(private data: DataProvaiderService) {}
  ngOnChanges(): void {
    // this.project = this.data.Projects.find(
    //   (x) => x.StudentId1 === this.user?.id
    // )!;
  }
}
