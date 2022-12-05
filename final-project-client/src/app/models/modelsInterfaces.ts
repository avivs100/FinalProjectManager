export enum UserType {
  admin,
  Student,
  lecturer,
}

export interface User {
  id: string;
  pass: string;
  userType: UserType;
  email: String;
}
