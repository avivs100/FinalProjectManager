using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeB
    {
        public PresentationGrade presentationGrade { get; set; }
        public BookGrade bookGrade { get; set; }
        public LecturerGrade lecturerGrade { get; set; }
        public double AverageScore { get; set; }
        public Guid gradeB_ID { get; set; }
        public double ComputeGrade()
        {
            AverageScore = presentationGrade.AverageScore * PresentationGrade.Precentage
                + bookGrade.AverageScore * BookGrade.Precentage
                + lecturerGrade.AverageScore * LecturerGrade.Precentage; ;
            return AverageScore;
        }
    }
}
