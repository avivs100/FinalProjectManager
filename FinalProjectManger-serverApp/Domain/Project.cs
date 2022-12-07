using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public long ProjectId { get; set; }
        public GradeA gradeA;
        public GradeB gradeB;
        public Lecturer lecturer { get; set; }
        public Student student1 { get; set; }
        public Student student2 { get; set; }
        public string ProjectName { get; set; }
    }
}
