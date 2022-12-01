using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeA
    {
        PresentationGrade presentationGrade { get; set; }
        BookGrade bookGrade { get; set; }
        LecturerGrade lecturerGrade { get; set; }
        double AverageScore { get; set; }

        public double ComputeGrade()
        {
            AverageScore = presentationGrade.AverageScore * PresentationGrade.Precentage
                + bookGrade.AverageScore * BookGrade.Precentage
                + lecturerGrade.AverageScore * LecturerGrade.Precentage; ;
            return AverageScore;
        }
    }
}
