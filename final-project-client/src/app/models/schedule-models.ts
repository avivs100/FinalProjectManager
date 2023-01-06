import { ProjectFull } from './project-grade-models';
import { Lecturer } from './users-models';

export interface ScheduleDates {
  id: number;
  date1: string;
  date2: string;
}

export interface LecturerConstarintForDate {
  lecturerId: number;
  date1: string;
  date2: string;
  sessions1: number[];
  sessions2: number[];
}

export interface Session {
  id: number;
  responsibleLecturer: Lecturer;
  lecturer2: Lecturer;
  lecturer3: Lecturer;
  projects: ProjectFull[];
  sessionNumber: number;
}

export interface DayInScheduleFull {
  id: number;
  firstDay: boolean;
  Session1: Session;
  Session2: Session;
  Session3: Session;
  Session4: Session;
  Session5: Session;
  Session6: Session;
}
export interface ScheduleFull {
  id: number;
  dayOne: DayInScheduleFull;
  dayTwo: DayInScheduleFull;
}
