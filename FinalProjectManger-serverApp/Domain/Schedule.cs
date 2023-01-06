using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.DayInSchedule;

namespace Domain
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DayOneID { get; set; }
        public int DayTwoID { get; set; }

        public Schedule() { }

        public Schedule(int dayOneID, int dayTwoID)
        {
            Id = new Random().Next();
            DayOneID = dayOneID;
            DayTwoID = dayTwoID;
        }

        public class ScheduleFull
        {
            public int Id { get; set; }
            public DayInScheduleFull DayOne { get; set; }
            public DayInScheduleFull DayTwo { get; set; }

            public  ScheduleFull(){}

            public ScheduleFull(int id, DayInScheduleFull dayOne, DayInScheduleFull dayTwo)
            {
                Id = id;
                DayOne = dayOne;
                DayTwo = dayTwo;
            }
        }
    }
}
