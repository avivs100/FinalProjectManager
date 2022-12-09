using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Lecturer
    {
        public long id { get; set; }
        public UserType userType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }        
        public List<Constraint> constraints { get; set; }

        public Lecturer(long id, UserType userType, string firstName, string lastName,string password)
        {
            constraints = new List<Constraint>();
            this.id = id;
            this.userType = userType;
            LastName = firstName;
            FirstName = lastName;
            this.password = password;
        }

        public Lecturer()
        {
        }
    }

    public class LecturerDetails
    {
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    public class Constraint
    {
        public Guid id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Constraint(int year, int month, int day, int hour, int minute, int second)
        {
            id = new Guid();
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}
