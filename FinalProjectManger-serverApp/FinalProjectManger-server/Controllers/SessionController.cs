using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Domain.Session;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        // GET: api/<SessionController>
        [HttpGet("GetAllFullSession")]
        public async Task<ActionResult<IReadOnlyList<SessionFull>>> GetAllFullSession()
        {
            var context = new UsersDbContext();
            var sessions = await context.Set<Session>().ToListAsync();
            var projects = await context.Set<Project>().ToListAsync();
            var fullsessions = new List<SessionFull>();
            foreach (var session in sessions)
            {
                var fullprojects = new List<ProjectFull>();
                var responsibleLecturer = await context.Set<Lecturer>().Where(x => x.id == session.ResponsibleLecturerID).FirstOrDefaultAsync();
                var lecturer2 = await context.Set<Lecturer>().Where(x => x.id == session.Lecturer2ID).FirstOrDefaultAsync();
                var lecturer3 = await context.Set<Lecturer>().Where(x => x.id == session.Lecturer3ID).FirstOrDefaultAsync();
                foreach (var proj in projects)
                {
                    var student1 = await context.Set<Student>().Where(x => x.id == proj.student1Id).FirstOrDefaultAsync();
                    var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
                    var lecturer = await context.Set<Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
                    var gradeA = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeAid == proj.gradeAId).FirstOrDefaultAsync();
                    var gradeB = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeBid == proj.gradeBId).FirstOrDefaultAsync();
                    var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB, proj.ProjectType,proj.projCode);
                    fullprojects.Add(fullProj);
                }
                var sessionFull = new SessionFull(session.Id, responsibleLecturer, lecturer2, lecturer3, fullprojects, session.SessionNumber, session.ClassRoom);
                fullsessions.Add(sessionFull);
            }
            return fullsessions;
        }




        //[HttpGet("GetAllFullSession")]
        //public async Task<ActionResult<IReadOnlyList<SessionFull>>> GetAllFullSession()
        //{
        //    var context = new UsersDbContext();
        //    var sessions = await context.Set<Session>().ToListAsync();
        //    var projects = await context.Set<Project>().ToListAsync();
        //    var fullsessions = new List<SessionFull>();
        //    foreach (var session in sessions)
        //    {
        //        var fullprojects = new List<ProjectFull>();
        //        var responsibleLecturer = await context.Set<Lecturer>().Where(x => x.id == session.ResponsibleLecturerID).FirstOrDefaultAsync();
        //        var lecturer2 = await context.Set<Lecturer>().Where(x => x.id == session.Lecturer2ID).FirstOrDefaultAsync();
        //        var lecturer3 = await context.Set<Lecturer>().Where(x => x.id == session.Lecturer3ID).FirstOrDefaultAsync();
        //        foreach (var proj in projects)
        //        {
        //            var student1 = await context.Set<Student>().Where(x => x.id == proj.student1Id).FirstOrDefaultAsync();
        //            var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
        //            var lecturer = await context.Set<Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
        //            var gradeA = await context.Set<GradeA>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeAid == proj.gradeAId).FirstOrDefaultAsync();
        //            var gradeB = await context.Set<GradeB>().Include(x => x.bookGrade).Include(x => x.presentationGrade).Include(x => x.lecturerGrade).Where(x => x.gradeBid == proj.gradeBId).FirstOrDefaultAsync();
        //            var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB, proj.ProjectType, "A");
        //            fullprojects.Add(fullProj);
        //        }
        //        var sessionFull = new SessionFull(session.Id, responsibleLecturer, lecturer2, lecturer3, fullprojects, session.SessionNumber);
        //        fullsessions.Add(sessionFull);
        //    }
        //    return fullsessions;
        //}


    }

}
