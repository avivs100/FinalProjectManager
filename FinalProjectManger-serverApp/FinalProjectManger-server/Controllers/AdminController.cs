using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
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
            var context = new UsersDbContext();
            var students = await context.Set<Student>().ToListAsync();
            foreach (var student in students)
            {
                var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
                SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
            }
            return Ok(true);
        }

        [HttpPut("SendEmailTo1Student{StudentId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Student([FromBody] EmailMessageDetails details, [FromRoute] long StudentId)
        {
            var context = new UsersDbContext();
            var student = await context.Set<Student>().Where(x => x.id == StudentId).FirstOrDefaultAsync();
            if(student == null)
                return NotFound(false);
            var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPut("SendEmailTo1Lecturer{LecturerId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Lecturer([FromBody] EmailMessageDetails details, [FromRoute] long LecturerId)
        {
            var context = new UsersDbContext();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == LecturerId).FirstOrDefaultAsync();
            if (lecturer == null)
                return NotFound(false);
            var msg = "Hi, " + lecturer.FirstName + lecturer.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            SendEmail(EmailMessageDetails.SystemEmail, lecturer.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPut("SendEmailTo2StudentsByProjectId{ProjectId}")]
        public async Task<ActionResult<bool>> SendEmaSendEmailTo2StudentsByProjectIdilTo1Lecturer([FromBody] EmailMessageDetails details, [FromRoute] long ProjectId)
        {
            var context = new UsersDbContext();
            var project = await context.Set<Project>().Where(x => x.ProjectId == ProjectId).FirstOrDefaultAsync();
            if (project == null)
                return NotFound(false);

            var student1 = await context.Set<Student>().Where(x => x.id == project.student1Id).FirstOrDefaultAsync();
            var student2 = await context.Set<Student>().Where(x => x.id == project.student2Id).FirstOrDefaultAsync();
            if (student1 == null || student2 == null)
                return NotFound(false);
            var msg = "Hi, " + student1.FirstName + " " + student1.LastName + " and " + student2.FirstName + " " + student2.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            SendEmail(EmailMessageDetails.SystemEmail, student1.Email, details.Subject, msg);
            SendEmail(EmailMessageDetails.SystemEmail, student2.Email, details.Subject, msg);
            return Ok(true);
        }

        void SendEmail(string from, string to, string subject, string msg)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                //message.IsBodyHtml = true;  
                message.Body = msg;
                smtp.Port = 587;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("FinalProjectManager@outlook.com", "AaSs2804");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }


    }
}
