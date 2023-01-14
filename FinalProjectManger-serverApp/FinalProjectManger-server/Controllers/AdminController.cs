using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using FinalProjectManger_server.Services;
using NuGet.Protocol.Plugins;
using System.Reflection;
using static Domain.Session;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Admin>>> ListAdmins()
        {
            var context = new UsersDbContext();
            return await context.Set<Admin>().ToListAsync();
        }
        [HttpGet("premissions")]
        public async Task<ActionResult<List<Premission>>> GetPremissions()
        {
            var context = new UsersDbContext();
            var premissions = await context.Set<Premission>().ToListAsync();
            return Ok(premissions);
        }
        [HttpGet("GetProposals")]
        public async Task<ActionResult<IReadOnlyList<ProjectProposal>>> GetProposals()
        {
            var context = new UsersDbContext();
            return await context.Set<ProjectProposal>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin([FromRoute] long id)
        {
            var context = new UsersDbContext();
            var admin = await context.Set<Admin>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }
        //// GET: api/<SessionController>
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
        //            var fullProj = new ProjectFull(proj.ProjectId, proj.ProjectName, lecturer, student1, student2, gradeA, gradeB, proj.ProjectType, proj.projCode);
        //            fullprojects.Add(fullProj);
        //        }
        //        var sessionFull = new SessionFull(session.Id, responsibleLecturer, lecturer2, lecturer3, fullprojects, session.SessionNumber, session.ClassRoom);
        //        fullsessions.Add(sessionFull);
        //    }
        //    return fullsessions;
        //}
        [HttpGet("GetLecturerPermissionToGiveGrades")]
        public async Task<ActionResult<List<LecturerPermissionToGiveGrades>>> GetLecturerPermissionToGiveGrades()
        {
            var context = new UsersDbContext();
            var premissions = await context.Set<LecturerPermissionToGiveGrades>().ToListAsync();
            return Ok(premissions);
        }

        [HttpGet("GetLecturerPermissionToGiveGradesFull")]
        public async Task<ActionResult<List<LecturerPermissionToGiveGradesFull>>> GetLecturerPermissionToGiveGradesFull()
        {
            var context = new UsersDbContext();
            var premissions = await context.Set<LecturerPermissionToGiveGrades>().ToListAsync();
            var lecturerPermissionToGiveGradesFull = new List<LecturerPermissionToGiveGradesFull>();
            foreach (var premission in premissions)
            {
                var lecturer = await context.Set<Lecturer>().Where(x => x.id == premission.Id).FirstOrDefaultAsync();
                var LecturerGrades = new List<LecturerGrade>();
                var BookGrades = new List<BookGrade>();
                var PresentationGrades = new List<PresentationGrade>();
                foreach (var item in premission.LecturerGradeId)
                {
                    var lecgrade = await context.Set<LecturerGrade>().Where(x => x.Id == item).FirstOrDefaultAsync();
                    if (lecgrade != null)
                        LecturerGrades.Add(lecgrade);
                }
                foreach (var item in premission.PresentationGradeId)
                {
                    var presentationgrade = await context.Set<PresentationGrade>().Where(x => x.Id == item).FirstOrDefaultAsync();
                    if (presentationgrade != null)
                        PresentationGrades.Add(presentationgrade);
                }
                foreach (var item in premission.BookGradeId)
                {
                    var bookgrade = await context.Set<BookGrade>().Where(x => x.Id == item).FirstOrDefaultAsync();
                    if (bookgrade != null)
                        BookGrades.Add(bookgrade);
                }
                var temp = new LecturerPermissionToGiveGradesFull(lecturer, PresentationGrades, BookGrades, LecturerGrades);
                lecturerPermissionToGiveGradesFull.Add(temp);
            }
            return Ok(lecturerPermissionToGiveGradesFull);
        }

        [HttpGet("GetAllProposalsAfterLecturerApprove")]
        public async Task<ActionResult<List<ProjectProposal>>> GetAllProposalsAfterLecturerApprove()
        {
            var context = new UsersDbContext();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            if (proposals == null)
                return NotFound();
            var proposalsApprovedByLec = new List<ProjectProposal>();
            foreach (var proposal in proposals)
            {
                if (proposal.IsApproved == true)
                {
                    proposalsApprovedByLec.Add(proposal);
                }
            }
            return Ok(proposalsApprovedByLec);
        }
        
        [HttpDelete("DeleteScheduleDates")]
        public async Task<ActionResult<bool>> DeleteScheduleDates()
        {
            var context = new UsersDbContext();
            var dates = await context.Set<ScheduleDates>().FirstOrDefaultAsync();
            if (dates == null) return NotFound(false);
            context.Set<ScheduleDates>().RemoveRange(dates);
            await context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpDelete("DeletePremission/{id}")]
        public async Task<ActionResult<bool>> DeletePremission([FromRoute] long id)
        {
            var context = new UsersDbContext();
            var premission = await context.Set<Premission>().Where(x => x.LecturerId == id).FirstOrDefaultAsync();
            if (premission == null) return NotFound(false);
            context.Set<Premission>().Remove(premission);
            await context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpPut("PutScheduleDates")]
        public async Task<ActionResult<ScheduleDates>> PutScheduleDates([FromBody] ScheduleDatesDetails details)
        {
            var context = new UsersDbContext();
            var scheduleDates = new ScheduleDates(details.date1, details.date2);
            var dates = await context.Set<ScheduleDates>().ToListAsync();
            context.Set<ScheduleDates>().RemoveRange(dates);
            await context.SaveChangesAsync();
            context.Set<ScheduleDates>().Add(scheduleDates);
            await context.SaveChangesAsync();
            return Ok(scheduleDates);
        }
        [HttpPut("SendEmailToAllStudents")]
        public async Task<ActionResult<bool>> SendEmailToAllStudents([FromBody] EmailMessageDetails details)
        {
            EmailService sender= new EmailService();
            var context = new UsersDbContext();
            var students = await context.Set<Student>().ToListAsync();
            foreach (var student in students)
            {
                var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
                sender.SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
            }
            return Ok(true);
        }

        [HttpPut("SendEmailToAllLecturers")]
        public async Task<ActionResult<bool>> SendEmailToAllLecturers([FromBody] EmailMessageDetails details)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            foreach (var lecturer in lecturers)
            {
                var msg = "Hi, " + lecturer.FirstName + lecturer.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
                sender.SendEmail(EmailMessageDetails.SystemEmail, lecturer.Email, details.Subject, msg);
            }
            return Ok(true);
        }

        [HttpPut("SendEmailToAllUsers")]
        public async Task<ActionResult<bool>> SendEmailToAllUsers([FromBody] EmailMessageDetails details)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            var students = await context.Set<Student>().ToListAsync();
            foreach (var lecturer in lecturers)
            {
                var msg = "Hi, " + lecturer.FirstName + lecturer.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
                sender.SendEmail(EmailMessageDetails.SystemEmail, lecturer.Email, details.Subject, msg);
            }
            foreach (var student in students)
            {
                var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
                sender.SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
            }
            return Ok(true);
        }

        [HttpPut("SendEmailTo1Student{StudentId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Student([FromBody] EmailMessageDetails details, [FromRoute] long StudentId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var student = await context.Set<Student>().Where(x => x.id == StudentId).FirstOrDefaultAsync();
            if(student == null)
                return NotFound(false);
            var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            sender.SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPut("SendEmailTo1Lecturer{LecturerId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Lecturer([FromBody] EmailMessageDetails details, [FromRoute] long LecturerId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == LecturerId).FirstOrDefaultAsync();
            if (lecturer == null)
                return NotFound(false);
            var msg = "Hi, " + lecturer.FirstName + lecturer.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            sender.SendEmail(EmailMessageDetails.SystemEmail, lecturer.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPut("SendEmailTo2StudentsByProjectId{ProjectId}")]
        public async Task<ActionResult<bool>> SendEmaSendEmailTo2StudentsByProjectIdilTo1Lecturer([FromBody] EmailMessageDetails details, [FromRoute] long ProjectId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var project = await context.Set<Project>().Where(x => x.ProjectId == ProjectId).FirstOrDefaultAsync();
            if (project == null)
                return NotFound(false);

            var student1 = await context.Set<Student>().Where(x => x.id == project.student1Id).FirstOrDefaultAsync();
            var student2 = await context.Set<Student>().Where(x => x.id == project.student2Id).FirstOrDefaultAsync();
            if (student1 == null || student2 == null)
                return NotFound(false);
            var msg = "Hi, " + student1.FirstName + " " + student1.LastName + " and " + student2.FirstName + " " + student2.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            sender.SendEmail(EmailMessageDetails.SystemEmail, student1.Email, details.Subject, msg);
            sender.SendEmail(EmailMessageDetails.SystemEmail, student2.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPost("ApproveLecturer/{id}")]
        public async Task<ActionResult<bool>> ApproveLecturer([FromRoute] long id)
        {

            var context = new UsersDbContext();

            var premission = await context.Set<Premission>().Where(x => x.LecturerId == id).FirstOrDefaultAsync();
            if (premission == null) return NotFound(false);
            context.Set<Premission>().Remove(premission);
            await context.SaveChangesAsync();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (lecturer == null) return NotFound(false);
            lecturer.IsActive = true;
            await context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("ApproveProposal/{proposalId}/{projCode}")]
        public async Task<ActionResult<bool>> ApproveProposal([FromRoute] int proposalId, [FromRoute] string projCode)
        {
            var context = new UsersDbContext();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            var proposal = await context.Set<ProjectProposal>().Where(x => x.Id == proposalId).FirstOrDefaultAsync();
            if (proposal == null)
                return NotFound(false);
            Project project = new Project();
            project.LecturerId = proposal.LecturerID;
            project.ProjectName = proposal.ProjectName;
            project.ProjectType = proposal.ProjectType;
            project.student1Id = proposal.Student1ID;
            project.student2Id = proposal.Student2ID;
            project.projCode= projCode;
            context.Remove(proposal);
            context.Add(project);
            await context.SaveChangesAsync();
            return Ok(true);

        }




    }
}
