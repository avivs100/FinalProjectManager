﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeA
    {
        public int gradeAid { get; set; }
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

        public GradeA()
        {
            gradeAid = new Random().Next();
            presentationGrade = new PresentationGrade();
            bookGrade = new BookGrade();
            lecturerGrade = new LecturerGrade();
        }
        public GradeA(PresentationGrade presentationGrade, BookGrade bookGrade, LecturerGrade lecturerGrade)
        {
            gradeAid = new Random().Next();
            this.presentationGrade = presentationGrade;
            this.bookGrade = bookGrade;
            this.lecturerGrade = lecturerGrade;
        }
    }
}
