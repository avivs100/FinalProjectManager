using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Admin
    {
        public long id { get; set; }
        public UserType userType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }

        public Admin(long id, UserType userType, string firstName, string lastName, string password)
        {
            this.id = id;
            this.userType = userType;
            LastName = lastName;
            FirstName = firstName;
            this.password = password;
        }
    }
}
