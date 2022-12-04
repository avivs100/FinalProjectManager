export interface User {
  id: string;
  pass: string;
}

export interface Grade {
  id: string;
  score: number;
}

export interface Project {
  id: string;
  name: string;
  student1Id: string;
  student2Id: string;
}
