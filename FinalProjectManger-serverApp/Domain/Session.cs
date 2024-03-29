﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Session;

namespace Domain
{

    public class Session
    {
        public int Id { get; set; }
        public long ResponsibleLecturerID { get; set; }
        public long Lecturer2ID { get; set; }
        public long Lecturer3ID { get; set; }
        public List<ProjectForSession> ProjectsForSessionID { get; set; }
        public int SessionNumber { get; set; }
        public string ClassRoom { get; set; }
        
        public Session() { }

        public Session(long responsibleLecturerID, long lecturer2ID, long lecturer3ID, List<ProjectForSession> projectsForSessionID, int sessionNumber)
        {
            Id = new Random().Next();
            ResponsibleLecturerID = responsibleLecturerID;
            Lecturer2ID = lecturer2ID;
            Lecturer3ID = lecturer3ID;
            ProjectsForSessionID = projectsForSessionID;
            SessionNumber = sessionNumber;
            ClassRoom = ConvertFromSessionNumToClassRoom(sessionNumber);
        }

        public Session(int id, long responsibleLecturerID, long lecturer2ID, long lecturer3ID, List<ProjectForSession> projectsForSessionID, int sessionNumber)
        {
            Id = id;
            ResponsibleLecturerID = responsibleLecturerID;
            Lecturer2ID = lecturer2ID;
            Lecturer3ID = lecturer3ID;
            ProjectsForSessionID = projectsForSessionID;
            SessionNumber = sessionNumber;
            ClassRoom = ConvertFromSessionNumToClassRoom(sessionNumber);
        }

        public class SessionFull
        {
            public int Id { get; set; }
            public Lecturer ResponsibleLecturer { get; set; }
            public Lecturer Lecturer2 { get; set; }
            public Lecturer Lecturer3 { get; set; }
            public List<ProjectInSession> Projects { get; set; }
            public int SessionNumber { get; set; }
            public string ClassRoom { get; set; }
            public SessionFull() { }

            public SessionFull(int id, Lecturer responsibleLecturer, Lecturer lecturer2, Lecturer lecturer3, List<ProjectInSession> projects, int sessionNumber, string classRoom)
            {
                Id = id;
                ResponsibleLecturer = responsibleLecturer;
                Lecturer2 = lecturer2;
                Lecturer3 = lecturer3;
                Projects = projects;
                SessionNumber = sessionNumber;
                ClassRoom = classRoom;
            }
        }
        public string ConvertFromSessionNumToClassRoom(int sessionNum)
        {
            if (sessionNum % 4 == 0)
                return ClassRoomNames.ClassRoom1Name;
            else if (sessionNum % 4 == 1)
                return ClassRoomNames.ClassRoom2Name;
            else if (sessionNum % 4 == 2)
                return ClassRoomNames.ClassRoom3Name;
            else
                return ClassRoomNames.ClassRoom4Name;

        }
        public class ClassRoomNames
        {
            public const string ClassRoom1Name = "L700";
            public const string ClassRoom2Name = "L701";
            public const string ClassRoom3Name = "L702";
            public const string ClassRoom4Name = "L703";
        }
    }
}
