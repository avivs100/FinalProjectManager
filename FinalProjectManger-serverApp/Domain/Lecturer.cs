using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Email { get; set; }
        public List<LecConstraint> constraints { get; set; }
        public bool IsActive { get; set; }

        public Lecturer(long id, UserType userType, string firstName, string lastName, string password, string email)
        {
            constraints = new List<LecConstraint>();
            this.id = id;
            this.userType = userType;
            LastName = firstName;
            FirstName = lastName;
            this.password = password;
            Email = email;
            IsActive = false;
        }

        public Lecturer(long id, UserType userType, string firstName, string lastName, string password, string email, bool isActive)
        {
            constraints = new List<LecConstraint>();
            this.id = id;
            this.userType = userType;
            LastName = firstName;
            FirstName = lastName;
            this.password = password;
            Email = email;
            IsActive = isActive;
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

    public class LecConstraint
    {
        public int Id;
        public int SessionNumber;

        public LecConstraint()
        {
            Id = new Random().Next();
        }
        public LecConstraint(int sessionNumber)
        {
            Id = new Random().Next();
            SessionNumber = sessionNumber;
        }
    }


}
