using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        public long id { get; set; }
        public UserType userType { get; set; }
        public long partnerId { get; set; }
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Student(long id, UserType userType,string firstName, string lastName, string password)
        {
            this.id = id;
            this.userType = userType;
            this.password = password;
            this.FirstName = firstName;
            LastName  = lastName;
        }
        public Student()
        {

        }
    }


    public class StudentDetails
    {
        public string password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
