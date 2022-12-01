using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LecturerGrade
    {
        public int Id { get; set; }
        public static double Precentage = 0.5;
        public int AverageScore { get; set; }
        //TODO: check with Naomi what grades need to be

        public int ComputeGrade()
        {
            AverageScore = 0; // add the hishuv
            return AverageScore;
        }
    }
}
