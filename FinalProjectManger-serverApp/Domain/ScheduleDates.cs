using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ScheduleDates
    {
        public ScheduleDates() { }
        public ScheduleDates(DateTime date1, DateTime date2)
        {
            this.id = new Random().Next();
            this.date1 = date1;
            this.date2 = date2;
        }

        public int id { get; set; }
        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
    }

    public class ScheduleDatesDetails
    {
        public ScheduleDatesDetails() { }
        public ScheduleDatesDetails(DateTime date1, DateTime date2)
        {
            this.date1 = date1;
            this.date2 = date2;
        }

        public DateTime date1 { get; set; }
        public DateTime date2 { get; set; }
    }
}
