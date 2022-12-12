export enum UserType {
  admin,
  Student,
  lecturer,
}

export enum ProjectType {
  Development = 'Development',
  Research = 'Research',
  Data = 'Data',
}

export interface User {
  id: number;
  pass: string;
  userType: UserType;
  email: String;
  firstName: string;
  lastName: string;
}

export interface Project {
  StudentId1: number;
  StudentId2: number;
  lecturerId: number;
  name: string;
  type: ProjectType;
  gradeA: GradeA;
  gradeB: GradeB;
}

export interface GradeA {
  lecturerScore: number;
  bookScore: number;
  presentationScore: number;
}
export interface GradeB {
  lecturerScore: number;
  bookScore: number;
  presentationScore: number;
}
