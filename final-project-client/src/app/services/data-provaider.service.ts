import { Injectable } from '@angular/core';
import {
  GradeA,
  GradeB,
  ProjectFull,
  ProjectType,
  User,
  UserType,
} from '../models/modelsInterfaces';

@Injectable({
  providedIn: 'root',
})
export class DataProvaiderService {
  public users: User[] = [];
  public gradesA: GradeA[] = [];
  public gradesB: GradeB[] = [];
  public Projects: ProjectFull[] = [];

  // constructor() {
  //   this.pushUsers();
  //   this.pushGradeAandGradeB();
  //   this.pushProjects();
  // }

  // public checkLogin(id: number, pass: string): User | null {
  //   // for (let i = 0; this.users.length; i++)
  //   console.log('values to check');
  //   console.log(id, pass);
  //   var userToCheck: User | null = null;
  //   this.users.forEach((user) => {
  //     if (user.id == id && user.pass == pass) userToCheck = user;
  //   });
  //   // if (this.users[i].id == id && this.users[i].pass == pass) {
  //   //   return this.users[i];
  //   // }
  //   // }
  //   return userToCheck;
  // }

  // public pushUsers() {
  //   this.users.push({
  //     email: 'avi1aviv2@gmail.com',
  //     id: 1,
  //     pass: '102030',
  //     userType: UserType.lecturer,
  //     firstName: 'Aviv',
  //     lastName: 'Shichman',
  //   });
  //   this.users.push({
  //     email: 'sagifishman1@gmail.com',
  //     id: 2,
  //     pass: '102030',
  //     userType: UserType.Student,
  //     firstName: 'Sagi',
  //     lastName: 'fishman',
  //   });
  //   this.users.push({
  //     email: 'sagifishman1@gmail.com',
  //     id: 3,
  //     pass: '102030',
  //     userType: UserType.Student,
  //     firstName: 'ohad',
  //     lastName: 'homo',
  //   });
  //   this.users.push({
  //     email: 'erez@gmail.com',
  //     id: 4,
  //     pass: '1',
  //     userType: UserType.lecturer,
  //     firstName: 'erz',
  //     lastName: 'erez',
  //   });
  //   this.users.push({
  //     email: 'sagifishman1@gmail.com',
  //     id: 5,
  //     pass: '102030',
  //     userType: UserType.Student,
  //     firstName: 'meni',
  //     lastName: 'halash',
  //   });
  //   this.users.push({
  //     email: 'sagifishman1@gmail.com',
  //     id: 6,
  //     pass: '102030',
  //     userType: UserType.Student,
  //     firstName: 'yona',
  //     lastName: 'yona',
  //   });
  // }

  // public pushGradeAandGradeB() {
  //   this.gradesA.push(
  //     {
  //       bookScore: 40,
  //       lecturerScore: 80,
  //       presentationScore: 95,
  //     },
  //     {
  //       bookScore: 90,
  //       lecturerScore: 80,
  //       presentationScore: 60,
  //     },
  //     {
  //       bookScore: 50,
  //       lecturerScore: 88,
  //       presentationScore: 97,
  //     }
  //   );

  //   this.gradesB.push(
  //     {
  //       bookScore: 56,
  //       lecturerScore: 87,
  //       presentationScore: 55,
  //     },
  //     {
  //       bookScore: 45,
  //       lecturerScore: 56,
  //       presentationScore: 99,
  //     },
  //     {
  //       bookScore: 46,
  //       lecturerScore: 35,
  //       presentationScore: 88,
  //     }
  //   );
  // }

  // public pushProjects() {
  //   this.Projects.push({
  //     gradeA: this.gradesA[0],
  //     gradeB: this.gradesA[0],
  //     lecturerId: this.users[0].id,
  //     name: 'project1',
  //     StudentId1: this.users[1].id,
  //     StudentId2: this.users[2].id,
  //     type: ProjectType.Data,
  //   });
  //   this.Projects.push({
  //     gradeA: this.gradesA[1],
  //     gradeB: this.gradesA[2],
  //     lecturerId: this.users[0].id,
  //     name: 'project2',
  //     StudentId1: this.users[4].id,
  //     StudentId2: this.users[5].id,
  //     type: ProjectType.Development,
  //   });
  // }
}
