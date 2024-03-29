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
  dayOne: DayInSchedule;
  dayTwo: DayInSchedule;
}

export interface DayInSchedule {
  classSessions1: ClassSessions;
  classSessions2: ClassSessions;
  classSessions3: ClassSessions;
  classSessions4: ClassSessions;
  id: number;
  day: boolean; //0 for first - 1 for second
}

export interface ClassSessions {
  session1: Session;
  session2: Session;
  session3: Session;
  session4: Session;
  session5: Session;
  className: string;
  id: number;
}

export interface ProjectInSession {
  projectFull: ProjectFull;
  order: number;
}

export interface Session {
  id: number;
  responsibleLecturer: Lecturer | null;
  lecturer2: Lecturer | null;
  lecturer3: Lecturer | null;
  projects: ProjectInSession[];
  sessionNumber: number;
  classRoom: string;
}
