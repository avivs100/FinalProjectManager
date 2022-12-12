using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        //public List<Grade> Grades { get; set; }
        public Lecturer Lecturer { get; set; }
        public Student student1 { get; set; }
        public Student student2 { get; set; }
        public GradeA gradeA { get; set; }
        //public GradeB gradeB { get; set; }

        public Project()
        {
                
        }
    }
}
