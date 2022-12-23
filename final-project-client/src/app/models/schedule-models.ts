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
