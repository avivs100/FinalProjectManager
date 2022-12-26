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
        public int Session6ID { get; set; }

        public DayInSchedule() { }

        public DayInSchedule(bool firstDay, int session1ID, int session2ID, int session3ID, int session4ID, int session5ID, int session6ID)
        {
            Id = new Random().Next();
            FirstDay = firstDay;
            Session1ID = session1ID;
            Session2ID = session2ID;
            Session3ID = session3ID;
            Session4ID = session4ID;
            Session5ID = session5ID;
            Session6ID = session6ID;
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
            public Session Session6 { get; set; }

            public DayInScheduleFull() { }

            public DayInScheduleFull(int id, bool firstDay, Session session1, Session session2, Session session3, Session session4, Session session5, Session session6)
            {
                Id = id;
                FirstDay = firstDay;
                Session1 = session1;
                Session2 = session2;
                Session3 = session3;
                Session4 = session4;
                Session5 = session5;
                Session6 = session6;
            }
        }
    }
}
