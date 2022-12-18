using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        // GET: api/<ProjectController>
        [HttpGet("GetProjects")]
        public async Task<ActionResult<IReadOnlyList<ProjectFull>>> GetProjects()
        {
            var projects = await context.Set<Project>().ToListAsync();
            var Fullprojects = new List<ProjectFull>();
            foreach (var proj in projects)
            {                
                var student1 = await context.Set<Student>().Where(x=>x.id == proj.student1Id).FirstOrDefaultAsync();
                var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
                var lecturer = await context.Set<Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
                var gradeA = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeAid == proj.gradeAId).FirstOrDefaultAsync();
                var gradeB = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeBid == proj.gradeBId).FirstOrDefaultAsync();
                var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB);
                Fullprojects.Add(fullProj);
            }
            return Fullprojects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectFull>> Get([FromRoute] int id)
        {
            var projects = await context.Set<Project>().ToListAsync();
            var proj = projects.Where(x => x.ProjectId == id).FirstOrDefault();
            if(proj == null) return NotFound();
            var student1 = await context.Set<Student>().Where(x => x.id == proj.student1Id).FirstOrDefaultAsync();
            var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
            var gradeA = await context.Set<GradeA>().Include(x=>x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeAid == proj.gradeAId).FirstOrDefaultAsync();
            var gradeB = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeBid == proj.gradeBId).FirstOrDefaultAsync();
            var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB);
            return Ok(fullProj);
        }

        [HttpPut]
        public async Task<ActionResult<Project>> Put([FromBody] ProjectDetails projectDetails)
        {
            var project = new Project();

            var student1 = await context.Set<Student>().Where(x => x.id == projectDetails.student1Id).FirstOrDefaultAsync();
            var student2 = await context.Set<Student>().Where(x => x.id == projectDetails.student2Id).FirstOrDefaultAsync();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == projectDetails.LecturerId).FirstOrDefaultAsync();
            var gradeA = await context.Set<GradeA>().Where(x => x.gradeAid == projectDetails.gradeAId).FirstOrDefaultAsync();
            var gradeB = await context.Set<GradeB>().Where(x => x.gradeBid == projectDetails.gradeBId).FirstOrDefaultAsync();
            if(student1 == null || student2 == null || lecturer == null || gradeA == null || gradeB == null)
                return NotFound();
            project.ProjectId = new Random().Next();
            project.LecturerId = projectDetails.LecturerId;
            project.ProjectName = projectDetails.ProjectName;
            project.gradeBId = projectDetails.gradeBId;
            project.gradeAId = projectDetails.gradeAId;
            project.student1Id = projectDetails.student1Id;
            project.student2Id = projectDetails.student2Id;
            context.Set<Project>().Add(project);
            //context.Add(project);
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> Delete([FromRoute] int id)
        {
            var projects = await context.Set<Project>().ToListAsync();
            var project = await context.Set<Project>().Where(x => x.ProjectId == id).FirstOrDefaultAsync();
            if (project != null)
            {
                context.Remove(project);
                context.SaveChanges();
                return Ok();
            }
            return NotFound();

        }

        [HttpGet("GetFullProjectByStudentId/{studentId}")]
        public async Task<ActionResult<ProjectFull>> GetFullProjectByStudentId([FromRoute] int studentId)
        {
            var projects = await context.Set<Project>().ToListAsync();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            var gradeAs = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var gradeBs = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var students = await context.Set<Student>().ToListAsync();
            var bookGrades = await context.Set<BookGrade>().ToListAsync();
            var presentationGrades = context.Set<PresentationGrade>().ToListAsync();
            var lecturerGrades = context.Set<LecturerGrade>().ToListAsync();
            var student = students.Where(x => x.id == studentId).FirstOrDefault();
            if (student == null)
                return NotFound();
            var project1 = projects.Where(x => x.student1Id == student.id).FirstOrDefault();
            if (project1 == null)
            {
               project1 = projects.Where(x => x.student2Id == student.id).FirstOrDefault();
            }
            if (project1 == null)
                return NotFound();
            ProjectFull FullProject = new ProjectFull();
            var s1 = students.Where(x => x.id == project1.student1Id).FirstOrDefault();
            var s2 = students.Where(x => x.id == project1.student2Id).FirstOrDefault();
            var l = lecturers.Where(x => x.id == project1.LecturerId).FirstOrDefault();
            var gradeA = gradeAs.Where(x => x.gradeAid == project1.gradeAId).FirstOrDefault();
            var gradeB = gradeBs.Where(x => x.gradeBid == project1.gradeBId).FirstOrDefault();
            FullProject.ProjectId = project1.ProjectId;
            FullProject.Lecturer = l;
            FullProject.ProjectName = project1.ProjectName;
            FullProject.student1 = s1;
            FullProject.student2 = s2;
            FullProject.gradeA = gradeA;
            FullProject.gradeB = gradeB;
            return Ok(FullProject);
        }
        [HttpGet("GetAllProjectsOfLecturer/{lecturerId}")]
        public async Task<ActionResult<IReadOnlyList<ProjectFull>>> GetAllProjectsOfLecturerr([FromRoute]int lecturerId)
        {
            var projects = await context.Set<Project>().ToListAsync();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            var gradeAs = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var gradeBs = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var students = await context.Set<Student>().ToListAsync();
            var projectsOfLecturer = new List<ProjectFull>();
            var lecturer = lecturers.Where(x => x.id == lecturerId).FirstOrDefault();
            if (lecturer == null)
                return NotFound();
            else
            {                
                foreach (var item in projects)
                {
                    if(item.LecturerId == lecturerId)
                    {
                        ProjectFull FullProject = new ProjectFull();
                        var s1 = students.FirstOrDefault(x => x.id == item.student1Id);
                        var s2 = students.FirstOrDefault(x => x.id == item.student2Id);
                        var l = lecturers.FirstOrDefault(x => x.id == item.LecturerId);
                        var gradeA = gradeAs.FirstOrDefault(x => x.gradeAid == item.gradeAId);
                        var gradeB = gradeBs.FirstOrDefault(x => x.gradeBid == item.gradeBId);
                        if (gradeA == null && gradeB == null && s1 == null && s2 == null && l == null)
                        {
                            return NotFound();
                        }
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
                return Ok(projectsOfLecturer);
            }
        }
    }
}
