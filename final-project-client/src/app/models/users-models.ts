import { UserType } from './enums';

export interface premission {
  id: string;
  lecturerId: number;
  lecturerName: string;
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
  SessionNumber: number;
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
