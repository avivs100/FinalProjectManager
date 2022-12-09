using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LecturerGrade//: GradeCollection
    {
       
        public Grade? Grade1 { get; set; }
        public Grade? Grade2 { get; set; }
        public long Id { get;  set; }
        public int AverageScore { get; set; }
        public string Description { get; set; } = null!;
        public static double Precentage = 0.5;

        //TODO: check with Naomi what grades need to be

        public LecturerGrade()
        {

        }
        public int ComputeGrade()
        {
            AverageScore = 0; // add the hishuv
            return AverageScore;
        }
    }
}
