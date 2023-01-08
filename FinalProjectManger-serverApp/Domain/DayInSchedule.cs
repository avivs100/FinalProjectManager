using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Session;

namespace Domain
{
    public class DayInSchedule
    {
        public int Id { get; set; }
        public bool FirstDay { get; set; }
        public int Session1ID { get; set; }
        public int Session2ID { get; set; }
        public int Session3ID { get; set; }
        public int Session4ID { get; set; }
        public int Session5ID { get; set; }

        public DayInSchedule() { }

        public DayInSchedule(bool firstDay, int session1ID, int session2ID, int session3ID, int session4ID, int session5ID)
        {
            Id = new Random().Next();
            FirstDay = firstDay;
            Session1ID = session1ID;
            Session2ID = session2ID;
            Session3ID = session3ID;
            Session4ID = session4ID;
            Session5ID = session5ID;
        }

        public class DayInScheduleFull
        {
            public int Id { get; set; }
            public bool FirstDay { get; set; }
            public Session Session1 { get; set; }
            public Session Session2 { get; set; }
            public Session Session3 { get; set; }
            public Session Session4 { get; set; }
            public Session Session5 { get; set; }

            public DayInScheduleFull() { }

            public DayInScheduleFull(int id, bool firstDay, Session session1, Session session2, Session session3, Session session4, Session session5)
            {
                Id = id;
                FirstDay = firstDay;
                Session1 = session1;
                Session2 = session2;
                Session3 = session3;
                Session4 = session4;
                Session5 = session5;
            }
        }
    }



public class DayInSchedule1
{
    public int ClassSessions1Id { get; set; }
    public int ClassSessions2Id { get; set; }
    public int ClassSessions3Id { get; set; }
    public int ClassSessions4Id { get; set; }
    public int Id { get; set; }
    public bool Day { get; set; }
    public DayInSchedule1()
    {
        Id = new Random().Next();
    }
    public DayInSchedule1(int classSessions1, int classSessions2, int classSessions3, int classSessions4, bool day)
    {
        Id = new Random().Next();
        ClassSessions1Id = classSessions1;
        ClassSessions2Id= classSessions2;
        ClassSessions3Id= classSessions3;
        ClassSessions4Id= classSessions4;
        Day= day;
    }
}


public class DayInScheduleFull1
{
    public ClassSessions ClassSessions1 { get; set; }
    public ClassSessions ClassSessions2 { get; set; }
    public ClassSessions ClassSessions3 { get; set; }
    public ClassSessions ClassSessions4 { get; set; }
    public int Id { get; set; }
    public bool Day { get; set; }
    public DayInScheduleFull1()
    {

    }
    public DayInScheduleFull1(ClassSessions classSessions1, ClassSessions classSessions2, ClassSessions classSessions3, ClassSessions classSessions4, bool day)
    {
        ClassSessions1 = classSessions1;
        ClassSessions2 = classSessions2;
        ClassSessions3 = classSessions3;
        ClassSessions4 = classSessions4;
        Day = day;
    }
}
}