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
        public List<Grade> Grades { get; set; }
        public Lecturer Lecturer { get; set; }
        public List<Student> students { get; set; }
        
        public Project(string projectName, Lecturer lecturer, Student student1, Student student2)
        {
            ProjectName = projectName;
            ProjectId = Guid.NewGuid();
            Grades = new List<Grade>();
            Lecturer = lecturer;
            students = new List<Student> { student1, student2 };
        }
    }
}
