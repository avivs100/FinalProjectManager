using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Session
    {
        public int Id { get; set; }
        public long ResponsibleLecturerID { get; set; }
        public long Lecturer2ID { get; set; }
        public long Lecturer3ID { get; set; }
        public List<Project> ProjectsID { get; set; }
        public int SessionNumber { get; set; }

        public Session() { }

        public Session(long responsibleLecturerID, long lecturer2ID, long lecturer3ID, List<Project> projectsID, int sessionNumber)
        {
            Id = new Random().Next();
            ResponsibleLecturerID = responsibleLecturerID;
            Lecturer2ID = lecturer2ID;
            Lecturer3ID = lecturer3ID;
            ProjectsID = projectsID;
            SessionNumber = sessionNumber;
        }

        public class SessionFull
        {
            public int Id { get; set; }
            public Lecturer ResponsibleLecturer { get; set; }
            public Lecturer Lecturer2 { get; set; }
            public Lecturer Lecturer3 { get; set; }
            public List<ProjectFull> Projects { get; set; }
            public int SessionNumber { get; set; }

            public SessionFull() { }

            public SessionFull(int id, Lecturer responsibleLecturer, Lecturer lecturer2, Lecturer lecturer3, List<ProjectFull> projects, int sessionNumber)
            {
                Id = id;
                ResponsibleLecturer = responsibleLecturer;
                Lecturer2 = lecturer2;
                Lecturer3 = lecturer3;
                Projects = projects;
                SessionNumber = sessionNumber;
            }
        }
    }
}
