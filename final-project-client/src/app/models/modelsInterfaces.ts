export enum UserType {
  admin,
  Student,
  lecturer,
  none,
}

export enum ProjectType {
  Development = 'Development',
  Research = 'Research',
  Data = 'Data',
}

export interface premission {
  id: string;
  lecturerId: number;
  lecturerName: string;
}

export interface User {
  id: number;
  pass: string;
  userType: UserType;
  email: String;
  firstName: string;
  lastName: string;
}

export interface Admin {
  id: number;
  password: string;
  userType: UserType;
  email: String;
  firstName: string;
  lastName: string;
}
export interface constraint {
  id: string;
  dataTime: Date;
}

export interface Lecturer {
  id: number;
  userType: UserType;
  password: string;
  email: String;
  firstName: string;
  lastName: string;
  constraints: constraint[];
  isActive: boolean;
}

export interface Student {
  id: number;
  userType: UserType;
  password: string;
  email: String;
  firstName: string;
  lastName: string;
  partnerId: number;
}

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
