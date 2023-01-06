
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGenetic
{
    public class Lecturer
    {
        public long id { get; set; }
        public List<int> constraints { get; set; } = new List<int>();

        public Lecturer(long id, List<int> constraints)
        {
            this.id = id;
            this.constraints = constraints;
        }


        //public Lecturer LecturerConverter(Domain.Lecturer lecturer)
        //{
        //    var constraintsList = new List<int>();
        //    foreach (var constraint in lecturer.constraints)
        //    {
        //        constraintsList.Add(constraint.SessionNumber);
        //    }
        //    return new Lecturer(lecturer.id, constraintsList);
        //}
    }


}
