using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGenetic
{
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
        public int gradeAId { get; set; }
        public int gradeBId { get; set; }
        public ProjectType ProjectType { get; set; }
        public string projCode { get; set; }
        public Project(string projectName, long lecturerId, long student1Id, long student2Id, int gradeAId, int gradeBId, ProjectType projectType, string projCode)
        {
            ProjectId = new Random().Next();
            ProjectName = projectName;
            LecturerId = lecturerId;
            this.student1Id = student1Id;
            this.student2Id = student2Id;
            this.gradeAId = gradeAId;
            this.gradeBId = gradeBId;
            ProjectType = projectType;
            this.projCode = projCode;
        }

        public Project()
        {
            ProjectId = new Random().Next();

        }
        public Project(int projId, long lecturerId)
        {
            ProjectId = projId;
            LecturerId = lecturerId;
        }
    }
}
