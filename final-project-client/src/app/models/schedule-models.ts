export interface ScheduleDates {
  id: number;
  date1: string;
  date2: string;
}

export interface LecturerConstarintForDate {
  lecturerId: number;
  date: string;
  sessions: number[];
}
