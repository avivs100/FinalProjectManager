using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using FinalProjectManger_server.Services;
using NuGet.Protocol.Plugins;
using System.Reflection;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        // GET: api/<AdminController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Admin>>> ListAdmins()
        {
            var context = new UsersDbContext();
            return await context.Set<Admin>().ToListAsync();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin([FromRoute] long id)
        {
            var context = new UsersDbContext();
            var admin = await context.Set<Admin>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (admin == null)
                return NotFound();
            return Ok(admin);
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



        [HttpGet("premissions")]
        public async Task<ActionResult<List<Premission>>> GetPremissions()
        {
            var context = new UsersDbContext();
            var premissions = await context.Set<Premission>().ToListAsync();
            return Ok(premissions);
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
    }
}
