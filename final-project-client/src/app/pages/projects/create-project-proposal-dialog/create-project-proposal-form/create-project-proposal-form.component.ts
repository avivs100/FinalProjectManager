import { Lecturer, Student } from './../../../../models/users-models';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProjectType } from 'src/app/models/enums';
import { RegisterFormData } from 'src/app/pages/register/register-page/register-page.component';

export interface ProposalFormData {
  projectName: string;
  projectType: ProjectType;
  student1ID: number;
  student2ID: number;
  lecturerID: number;
  projectCategoryExplain: string;
  keywords: string;
  generalDescriptionOfTheProblem: string;
  mainToolsThatWillBeUsedForSolvingTheProblem: string;
  plannedWorkingProcessDuringTheFirstSemester: string;
  productOfTheWorkOfTheFirstSemester: string;
}
@Component({
  selector: 'app-create-project-proposal-form',
  templateUrl: './create-project-proposal-form.component.html',
})
export class CreateProjectProposalFormComponent {
  @Output() public save = new EventEmitter<ProposalFormData>();
  @Input() lecturers: Lecturer[] | null = null;
  @Input() Students: Student[] | null = null;

  constructor(private fb: FormBuilder) {}

  public form: FormGroup = this.fb.group({
    projectName: ['', Validators.required],
    projectType: ['', Validators.required],
    student1ID: ['', Validators.required],
    student2ID: ['', Validators.required],
    lecturerID: ['', Validators.required],
    projectCategoryExplain: ['', Validators.required],
    generalDescriptionOfTheProblem: ['', Validators.required],
    mainToolsThatWillBeUsedForSolvingTheProblem: ['', Validators.required],
    plannedWorkingProcessDuringTheFirstSemester: ['', Validators.required],
    productOfTheWorkOfTheFirstSemester: ['', Validators.required],
    keywords: ['', Validators.required],
  });

  onSubmit(formData: ProposalFormData) {
    this.save.emit(formData);
  }
}
