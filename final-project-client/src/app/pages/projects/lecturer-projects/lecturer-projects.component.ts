import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Project, User } from 'src/app/models/modelsInterfaces';
import { DataProvaiderService } from 'src/app/services/data-provaider.service';

@Component({
  selector: 'app-lecturer-projects',
  templateUrl: './lecturer-projects.component.html',
  styleUrls: ['./lecturer-projects.component.scss'],
})
export class LecturerProjectsComponent implements OnChanges {
  selectedProduct($event: any) {
    throw new Error('Method not implemented.');
  }
  public projects: Project[] = [];

  @Input() public user: User | null = null;

  constructor(private data: DataProvaiderService) {}
  ngOnChanges(): void {
    // this.projects = this.data.Projects.filter(
    //   (x) => x.lecturerId === this.user!.id
    // );
  }
}
