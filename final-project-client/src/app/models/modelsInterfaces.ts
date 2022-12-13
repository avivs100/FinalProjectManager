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

export interface Admin {
  id: number;
  pass: string;
  userType: UserType;
  //email: String;
  firstName: string;
  lastName: string;
}
export interface constraint {
  id: string;
  dataTime: Date;
}

export interface Lecturer {
  id: number;
  pass: string;
  userType: UserType;
  //email: String;
  firstName: string;
  lastName: string;
  constraints: constraint[];
}

export interface Student {
  id: number;
  pass: string;
  userType: UserType;
  //email: String;
  firstName: string;
  lastName: string;
  partnerId: number;
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
