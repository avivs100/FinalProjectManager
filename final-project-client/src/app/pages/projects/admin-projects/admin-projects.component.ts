import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ProjectFull } from 'src/app/models/project-grade-models';
import * as FileSaver from 'file-saver';
import { AdminApiService } from 'src/app/services/admin-api.service';
import { StateService } from 'src/app/services/state.service';

export interface forExcel {
  projectName: string;
  projectType: string;
  projCode: string;
  lecturer: string;
  lecturerId: string;
  student1: string;
  student1Id: string;
  student2: string;
  student2Id: string;
}

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
  public projects: ProjectFull[] = [];
  public projects$ = this.adminApi.getProjects();
  public sub = new Subscription();

  ngOnInit(): void {
    this.sub.add(this.projects$.subscribe((x) => (this.projects = x)));
  }

  public projectToProjectToExel(projectsTo: ProjectFull[]): forExcel[] {
    var projs: forExcel[] = [];
    projectsTo.forEach((x) =>
      projs.push({
        student1: x.student1.firstName + ' ' + x.student1.lastName,
        student1Id: x.student1.id.toString(),
        student2: x.student2.firstName + ' ' + x.student2.lastName,
        student2Id: x.student2.id.toString(),
        lecturer: x.lecturer.firstName + ' ' + x.lecturer.lastName,
        lecturerId: x.lecturer.id.toString(),
        projCode: x.projCode,
        projectName: x.projectName,
        projectType: x.projectType == 0 ? 'Research' : 'Development',
      })
    );
    return projs;
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

  exportExcel() {
    import('xlsx').then((xlsx) => {
      const worksheet = xlsx.utils.json_to_sheet(
        this.projectToProjectToExel(this.projects)
      );
      const workbook = { Sheets: { data: worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, {
        bookType: 'xlsx',
        type: 'array',
      });
      this.saveAsExcelFile(excelBuffer, 'products');
    });
  }

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE =
      'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE,
    });
    FileSaver.saveAs(
      data,
      fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION
    );
  }

  exportPdf() {
    console.log('pdf');
  }
}
