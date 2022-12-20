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
        public string Email { get; set; }
        public Student(long id, UserType userType,string firstName, string lastName, string password, string email)
        {
            this.id = id;
            this.userType = userType;
            this.password = password;
            this.FirstName = firstName;
            LastName = lastName;
            Email = email;
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

    public class DetailsForRegister
    {
        public long Id { get; set; }
        public bool IsLecturer { get; set; }
        public string Password { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string Email { get; set; } = null!;

    }

}
