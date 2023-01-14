using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

    public enum ProjectType
    {
        Research,
        Development
    }
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public long LecturerId { get; set; }
        public long student1Id { get; set; }
        public long student2Id { get; set; }
        public ProjectType ProjectType { get; set; }
        public string projCode { get; set; }
        public Project(string projectName, long lecturerId, long student1Id, long student2Id, ProjectType projectType, string projCode)
        {
            ProjectId = new Random().Next();
            ProjectName = projectName;
            LecturerId = lecturerId;
            this.student1Id = student1Id;
            this.student2Id = student2Id;
            ProjectType = projectType;
            this.projCode = projCode;
        }

        public Project()
        {
            ProjectId = new Random().Next();
        }
    }



public class ProjectFull
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public Lecturer Lecturer { get; set; }
    public Student student1 { get; set; }
    public Student student2 { get; set; }
    public ProjectType ProjectType { get; set; }
    public string projCode { get; set; }

    public ProjectFull(int projectId, string projectName, Lecturer lecturer, Student student1, Student student2, ProjectType projectType, string projCode)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        Lecturer = lecturer;
        this.student1 = student1;
        this.student2 = student2;
        ProjectType = projectType;
        this.projCode = projCode;
    }
    public ProjectFull()
    {

    }

}

public class ProjectInSession
{
    public ProjectFull ProjectFull { get; set; }
    public int Order { get; set; }

    public ProjectInSession(ProjectFull projectFull, int order)
    {
        ProjectFull = projectFull;
        Order = order;
    }
}

public class ProjectDetails
{
    public string ProjectName { get; set; }
    public long LecturerId { get; set; }
    public long student1Id { get; set; }
    public long student2Id { get; set; }
    public ProjectType ProjectType { get; set; }
    //public int gradeAId { get; set; }
    //public int gradeBId { get; set; }
}