using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Project> projects = context.Set<Project>().ToList();
        List<Student> students = context.Set<Student>().ToList();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        List<GradeA> gradeAs = context.Set<GradeA>().ToList();
        List<GradeB> gradeBs = context.Set<GradeB>().ToList();
        // GET: api/<ProjectController>
        [HttpGet]
        public IEnumerable<ProjectFull> Get()
        {
            var Fullprojects = new List<ProjectFull>();
            foreach (var proj in projects)
            {                
                var student1 = students.Find(x=>x.id == proj.student1Id);
                var student2 = students.Find(x => x.id == proj.student2Id);
                var lecturer = lecturers.Find(x => x.id == proj.LecturerId);
                var gradeA = gradeAs.Find(x => x.gradeAid == proj.gradeAId);
                var gradeB = gradeBs.Find(x => x.gradeBid == proj.gradeBId);
                var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB);
                Fullprojects.Add(fullProj);
            }
            return Fullprojects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get([FromRoute] int id)
        {
            var project = projects.Find(x => x.ProjectId == id);
            return project;
        }

        // POST api/<ProjectController>
        [HttpPost("{id}")]
        public bool Post([FromRoute] long id, [FromBody] ProjectDetails projectDetails)
        {
            if (!(projects.Any(x => x.ProjectId == id)))
            {
                return false;
            }
            var project = projects.Find(x => x.ProjectId == id);
            context.Remove(project);
            context.SaveChanges();
            project.LecturerId = projectDetails.LecturerId;
            project.ProjectName = projectDetails.ProjectName;
            project.gradeBId = projectDetails.gradeBId;
            project.gradeAId = projectDetails.gradeAId;
            context.Add(project);
            context.SaveChanges();
            return true;
        }

        // PUT api/<ProjectController>/5
        [HttpPut]
        public void Put([FromBody] ProjectDetails projectDetails)
        {
            var project = new Project();
            project.ProjectId = new Random().Next();
            project.LecturerId = projectDetails.LecturerId;
            project.ProjectName = projectDetails.ProjectName;
            project.gradeBId = projectDetails.gradeBId;
            project.gradeAId = projectDetails.gradeAId;
            context.Add(project);
            context.SaveChanges();
        }

        //[HttpPut("PutNewProjectBy2IdOfStudents")]
        //public void PutNewProjectBy2IdOfStudents([FromBody] List<long> Ids)
        //{
        //    var project = new Project();
        //    project.ProjectId = new Random().Next();
        //    project.LecturerId = projectDetails.LecturerId;
        //    project.ProjectName = projectDetails.ProjectName;
        //    project.gradeBId = projectDetails.gradeBId;
        //    project.gradeAId = projectDetails.gradeAId;
        //    context.Add(project);
        //    context.SaveChanges();
        //}

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public bool Delete([FromRoute] int id)
        {
            if (projects.Any(x => x.ProjectId == id))
            {
                var projToDelete = projects.Find(x => x.ProjectId == id);
                context.Remove(projToDelete);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        [HttpGet("GetFullProjectByIdProject{id}")]
        public ProjectFull GetFullProjectByIdProject([FromRoute] int id)
        {
            var FullProject = new ProjectFull();
            var project = projects.Find(x => x.ProjectId == id);
            if (project == null)
                return null;
            else
            {
                var students = context.Set<Student>().ToList();
                var lecturers = context.Set<Lecturer>().ToList();
                var gradeAs = context.Set<GradeA>().ToList();
                var gradeBs = context.Set<GradeB>().ToList();
                var s1 = students.Find(x => x.id == project.student1Id);
                var s2 = students.Find(x => x.id == project.student2Id);
                var l = lecturers.Find(x => x.id == project.LecturerId);
                var gradeA = gradeAs.Find(x => x.gradeAid == project.gradeAId);
                var gradeB = gradeBs.Find(x => x.gradeBid == project.gradeBId);
                FullProject.ProjectId = project.ProjectId;
                FullProject.Lecturer = l;
                FullProject.ProjectName = project.ProjectName;
                FullProject.student1 = s1;
                FullProject.student2 = s2;
                FullProject.gradeA = gradeA;
                FullProject.gradeB = gradeB;
            }
            return FullProject;
        }

        [HttpGet("GetFullProjectByStudentId{studentId}")]
        public ProjectFull GetFullProjectByStudentId([FromRoute]int studentId)
        {
            var lecturers = context.Set<Lecturer>().ToList();
            var gradeAs = context.Set<GradeA>().ToList();
            var gradeBs = context.Set<GradeB>().ToList();
            var students = context.Set<Student>().ToList();
            var bookGrades= context.Set<BookGrade>().ToList();
            var presentationGrades = context.Set<PresentationGrade>().ToList();
            var lecturerGrades = context.Set<LecturerGrade>().ToList();
            Student student;
            try
            {
                student = students.Find(x => x.id == studentId);
            }
            catch (Exception ex)
            {
                student = null;
            }
            if (student == null)
                return null;
            Project project1, project2;
            try
            {
                project1 = projects.Find(x => x.student1Id == student.id);
            }
            catch (Exception ex)
            {
                project1 = null;
            }
            if (project1 == null)
            {
                try
                {
                    project1 = projects.Find(x => x.student2Id == student.id);
                }
                catch (Exception ex)
                {
                    project1 = null;
                }
            }
            if (project1 == null)
            {
                return null;
            }
            else
            {
                ProjectFull FullProject = new ProjectFull();
                var s1 = students.Find(x => x.id == project1.student1Id);
                var s2 = students.Find(x => x.id == project1.student2Id);
                var l = lecturers.Find(x => x.id == project1.LecturerId);
                var gradeA = gradeAs.Find(x => x.gradeAid == project1.gradeAId);
                var gradeB = gradeBs.Find(x => x.gradeBid == project1.gradeBId);
                FullProject.ProjectId = project1.ProjectId;
                FullProject.Lecturer = l;
                FullProject.ProjectName = project1.ProjectName;
                FullProject.student1 = s1;
                FullProject.student2 = s2;
                FullProject.gradeA = gradeA;
                FullProject.gradeB = gradeB;
                return FullProject;
            }
            return null;
        }
        [HttpGet("GetAllProjectsOfLecturer{lecturerId}")]
        public List<ProjectFull> GetAllProjectsOfLecturer([FromRoute]int lecturerId)
        {
            var gradeAs = context.Set<GradeA>().ToList();
            var gradeBs = context.Set<GradeB>().ToList();
            var students = context.Set<Student>().ToList();
            var lecturers = context.Set<Lecturer>().ToList();
            var projectsOfLecturer = new List<ProjectFull>();
            Lecturer lecturer;
            try
            {
                lecturer = lecturers.Find(x => x.id == lecturerId);
            }
            catch (Exception ex)
            {
                lecturer = null;
            }
            if (lecturer == null)
                return null;
            else
            {
                
                foreach (var item in projects)
                {
                    if(item.LecturerId == lecturerId)
                    {
                        ProjectFull FullProject = new ProjectFull();
                        var s1 = students.Find(x => x.id == item.student1Id);
                        var s2 = students.Find(x => x.id == item.student2Id);
                        var l = lecturers.Find(x => x.id == item.LecturerId);
                        var gradeA = gradeAs.Find(x => x.gradeAid == item.gradeAId);
                        var gradeB = gradeBs.Find(x => x.gradeBid == item.gradeBId);
                        FullProject.ProjectId = item.ProjectId;
                        FullProject.Lecturer = l;
                        FullProject.ProjectName = item.ProjectName;
                        FullProject.student1 = s1;
                        FullProject.student2 = s2;
                        FullProject.gradeA = gradeA;
                        FullProject.gradeB = gradeB;
                        projectsOfLecturer.Add(FullProject);
                    }
                    
                }
                return projectsOfLecturer;
            }
        }
    }
}
