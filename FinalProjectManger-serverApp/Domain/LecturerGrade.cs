﻿using System;
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
        public int Id { get;  set; }
        public int AverageScore { get; set; } = 0;
        public string Description { get; set; } = null!;
        public static double Precentage = 0.5;

        //TODO: check with Naomi what grades need to be

        public LecturerGrade()
        {
            Id = new Random().Next();
            Grade1 = new Grade(0.5, "Grade 1");
            Grade2 = new Grade(0.5, "Grade 2");
            Description = "";
        }
        public LecturerGrade(Grade? grade1, Grade? grade2, string description)
        {
            Grade1 = grade1;
            Grade2 = grade2;
            Id = new Random().Next();
            Description = description;
        }

        public int ComputeGrade()
        {
            AverageScore = 0; // add the hishuv
            return AverageScore;
        }
    }
}
