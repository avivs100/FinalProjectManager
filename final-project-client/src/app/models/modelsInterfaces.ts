export enum UserType {
  admin,
  Student,
  lecturer,
}

export interface User {
  id: number;
  pass: string;
  userType: UserType;
  email: String;
  firstName: string;
  lastName: string;
}
