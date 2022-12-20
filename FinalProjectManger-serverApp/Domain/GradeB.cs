using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeB
    {
        public int gradeBid { get; set; }
        public PresentationGrade presentationGrade { get; set; }
        public BookGrade bookGrade { get; set; }
        public LecturerGrade lecturerGrade { get; set; }
        public double AverageScore { get; set; }
        
        public double ComputeGrade()
        {
            AverageScore = presentationGrade.AverageScore * PresentationGrade.Precentage
                + bookGrade.AverageScore * BookGrade.Precentage
                + lecturerGrade.AverageScore * LecturerGrade.Precentage; ;
            return AverageScore;
        }

        public GradeB()
        {
            gradeBid = new Random().Next();
            presentationGrade = new PresentationGrade();
            bookGrade = new BookGrade();
            lecturerGrade = new LecturerGrade();

        }
        public GradeB(PresentationGrade presentationGrade, BookGrade bookGrade, LecturerGrade lecturerGrade)
        {
            gradeBid = new Random().Next();
            this.bookGrade = bookGrade;
            this.presentationGrade = presentationGrade;
            this.lecturerGrade = lecturerGrade;
            
        }
    }
}
