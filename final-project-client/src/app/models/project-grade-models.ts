import { ProjectType } from './enums';
import { Lecturer, Student } from './users-models';

export interface Grade {
  description: string;
  gradeCollectionId: number;
  score: number;
  precentage: number;
  name: string;
}
export interface PresentationGrade {
  id: number;
  organization: Grade;
  qualityOfProblem: Grade;
  technicalQuality: Grade;
  generalEvaluation: Grade;
  additionalComment: string;
  averageScore: number;
}

export interface BookGrade {
  id: number;
  averageScore: number;
}

export interface LecturerGrade {
  id: number;
  averageScore: number;
  description: string;
  grade1: Grade;
  grade2: Grade;
}

export interface ProjectIds {
  StudentId1: number;
  StudentId2: number;
  lecturerId: number;
  name: string;
  type: ProjectType;
  gradeA: GradeA;
  gradeB: GradeB;
}

export interface GradeA {
  gradeAid: number;
  presentationGrade: PresentationGrade;
  bookGrade: BookGrade;
  lecturerGrade: LecturerGrade;
}

export interface GradeB {
  gradeBid: number;
  presentationGrade: PresentationGrade;
  bookGrade: BookGrade;
  lecturerGrade: LecturerGrade;
  averageScore: number;
}
export interface ProjectFull {
  projectId: number;
  projectName: string;
  lecturer: Lecturer;
  student1: Student;
  student2: Student;
  gradeB: GradeB;
  gradeA: GradeA;
}
