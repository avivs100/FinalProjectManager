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
        
        [HttpGet("GetProjects")]
        public async Task<ActionResult<IReadOnlyList<ProjectFull>>> GetProjects()
        {
            var context = new UsersDbContext();
            var projects = await context.Set<Project>().ToListAsync();
            var fullprojects = new List<ProjectFull>();
            foreach (var proj in projects)
            {                
                var student1 = await context.Set<Student>().Where(x=>x.id == proj.student1Id).FirstOrDefaultAsync();
                var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
                var lecturer = await context.Set<Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
                var gradeA = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeAid == proj.gradeAId).FirstOrDefaultAsync();
                var gradeB = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeBid == proj.gradeBId).FirstOrDefaultAsync();
                var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB);
                fullprojects.Add(fullProj);
            }
            return fullprojects;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectFull>> Get([FromRoute] int id)
        {
            var context = new UsersDbContext();
            var projects = await context.Set<Project>().ToListAsync();
            var proj = projects.FirstOrDefault(x => x.ProjectId == id);
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
            var context = new UsersDbContext();
            var project = new Project();

            var student1 = await context.Set<Student>().Where(x => x.id == projectDetails.student1Id).FirstOrDefaultAsync();
            var student2 = await context.Set<Student>().Where(x => x.id == projectDetails.student2Id).FirstOrDefaultAsync();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == projectDetails.LecturerId).FirstOrDefaultAsync();
            //var gradeA = await context.Set<GradeA>().Where(x => x.gradeAid == projectDetails.gradeAId).FirstOrDefaultAsync();
            //var gradeB = await context.Set<GradeB>().Where(x => x.gradeBid == projectDetails.gradeBId).FirstOrDefaultAsync();
            if(student1 == null || student2 == null || lecturer == null/* || gradeA == null || gradeB == null*/)
                return NotFound();
            project.ProjectId = new Random().Next();
            project.LecturerId = projectDetails.LecturerId;
            project.ProjectName = projectDetails.ProjectName;
            var gradeB = new GradeB();
            context.Set<GradeB>().Add(gradeB);
            await context.SaveChangesAsync();
            var gradeA = new GradeA();
            context.Set<GradeA>().Add(gradeA);
            await context.SaveChangesAsync();
            project.gradeBId = gradeB.gradeBid;
            project.gradeAId = gradeA.gradeAid;
            project.student1Id = projectDetails.student1Id;
            project.student2Id = projectDetails.student2Id;
            context.Set<Project>().Add(project);

            //context.Add(project);
            await context.SaveChangesAsync();
            return Ok();

        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> Delete([FromRoute] int id)
        {
            var context = new UsersDbContext();
            var projects = await context.Set<Project>().ToListAsync();
            var project = await context.Set<Project>().Where(x => x.ProjectId == id).FirstOrDefaultAsync();
            if (project == null) return NotFound();
            context.Remove(project);
            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet("GetFullProjectByStudentId/{studentId}")]
        public async Task<ActionResult<ProjectFull>> GetFullProjectByStudentId([FromRoute] int studentId)
        {
            var context = new UsersDbContext();
            var projects = await context.Set<Project>().ToListAsync();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            var gradeAs = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var gradeBs = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var students = await context.Set<Student>().ToListAsync();
            var bookGrades = await context.Set<BookGrade>().ToListAsync();
            var presentationGrades = context.Set<PresentationGrade>().ToListAsync();
            var lecturerGrades = context.Set<LecturerGrade>().ToListAsync();
            var student = students.FirstOrDefault(x => x.id == studentId);
            if (student == null)
                return NotFound();
            var project1 = projects.FirstOrDefault(x => x.student1Id == student.id) ?? projects.FirstOrDefault(x => x.student2Id == student.id);
            if (project1 == null)
                return NotFound();
            var fullProject = new ProjectFull();
            var s1 = students.FirstOrDefault(x => x.id == project1.student1Id);
            var s2 = students.FirstOrDefault(x => x.id == project1.student2Id);
            var l = lecturers.FirstOrDefault(x => x.id == project1.LecturerId);
            var gradeA = gradeAs.FirstOrDefault(x => x.gradeAid == project1.gradeAId);
            var gradeB = gradeBs.FirstOrDefault(x => x.gradeBid == project1.gradeBId);
            fullProject.ProjectId = project1.ProjectId;
            fullProject.Lecturer = l;
            fullProject.ProjectName = project1.ProjectName;
            fullProject.student1 = s1;
            fullProject.student2 = s2;
            fullProject.gradeA = gradeA;
            fullProject.gradeB = gradeB;
            return Ok(fullProject);
        }

        [HttpGet("GetScheduleDates")]
        public async Task<ActionResult<ScheduleDates>> GetScheduleDates()
        {
            var context = new UsersDbContext();
            var scheduleDates = await context.Set<ScheduleDates>().FirstOrDefaultAsync();
            return Ok(scheduleDates);
        }

        [HttpGet("GetAllProjectsOfLecturer/{lecturerId}")]
        public async Task<ActionResult<IReadOnlyList<ProjectFull>>> GetAllProjectsOfLecturer([FromRoute]int lecturerId)
        {
            var context = new UsersDbContext();
            var projects = await context.Set<Project>().ToListAsync();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            var gradeAs = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var gradeBs = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).ToListAsync();
            var students = await context.Set<Student>().ToListAsync();
            var projectsOfLecturer = new List<ProjectFull>();
            var lecturer = lecturers.FirstOrDefault(x => x.id == lecturerId);
            if (lecturer == null)
                return NotFound(null);
            else
            {                
                foreach (var item in projects)
                {
                    if(item.LecturerId == lecturerId)
                    {
                        var fullProject = new ProjectFull();
                        var s1 = students.FirstOrDefault(x => x.id == item.student1Id);
                        var s2 = students.FirstOrDefault(x => x.id == item.student2Id);
                        var l = lecturers.FirstOrDefault(x => x.id == item.LecturerId);
                        var gradeA = gradeAs.FirstOrDefault(x => x.gradeAid == item.gradeAId);
                        var gradeB = gradeBs.FirstOrDefault(x => x.gradeBid == item.gradeBId);
                        if (gradeA == null && gradeB == null && s1 == null && s2 == null && l == null)
                        {
                            return NotFound(null);
                        }
                        fullProject.ProjectId = item.ProjectId;
                        fullProject.Lecturer = l!;
                        fullProject.ProjectName = item.ProjectName;
                        fullProject.student1 = s1!;
                        fullProject.student2 = s2!;
                        fullProject.gradeA = gradeA!;
                        fullProject.gradeB = gradeB!;
                        projectsOfLecturer.Add(fullProject);
                    }
                    
                }
                return Ok(projectsOfLecturer);
            }
        }
    }
}
