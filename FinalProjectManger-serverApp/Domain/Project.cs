using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public long LecturerId { get; set; }
        public long student1Id { get; set; }
        public long student2Id { get; set; }
        public int gradeAId { get; set; }
        public int gradeBId { get; set; }

        public Project(string projectName, long lecturerId, long student1Id, long student2Id, int gradeAId, int gradeBId)
        {
            ProjectId = new Random().Next();
            ProjectName = projectName;
            LecturerId = lecturerId;
            this.student1Id = student1Id;
            this.student2Id = student2Id;
            this.gradeAId = gradeAId;
            this.gradeBId = gradeBId;
        }

        public Project()
        {

        }
    }


}
public class ProjectFull
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public Lecturer Lecturer { get; set; }
    public Student student1 { get; set; }
    public Student student2 { get; set; }
    public GradeA gradeA { get; set; }
    public GradeB gradeB { get; set; }

    public ProjectFull(int projectId, string projectName, Lecturer lecturer, Student student1, Student student2, GradeA gradeA, GradeB gradeB)
    {
        ProjectId= projectId;
        ProjectName= projectName;
        Lecturer= lecturer;
        this.student1= student1;
        this.student2= student2;
        this.gradeA=gradeA;
        this.gradeB=gradeB;
    }
    public ProjectFull()
    {

    }

}

public class ProjectDetails
{
    public string ProjectName { get; set; }
    public long LecturerId { get; set; }
    public long student1Id { get; set; }
    public long student2Id { get; set; }
    //public int gradeAId { get; set; }
    //public int gradeBId { get; set; }
}
