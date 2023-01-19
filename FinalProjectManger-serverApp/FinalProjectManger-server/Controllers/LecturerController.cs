using Data;
using Domain;
using FinalProjectManger_server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {


        // GET: api/<LecturerController>
        [HttpGet("ListLecturers")]
        public async Task<ActionResult<IReadOnlyList<Lecturer>>> ListLecturers()
        {
            var context = new UsersDbContext();
            return await context.Set<Lecturer>().Include(x=>x.constraints).ToListAsync();
        }

        // GET api/<LecturerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> Get([FromRoute] long id)
        {
            var context = new UsersDbContext();
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (lecturer == null)
            {
                return NotFound();
            }
            else
                return Ok(lecturer);
        }

        [HttpGet("ScheduleDates")]
        public async Task<ActionResult<IReadOnlyList<ScheduleDates>>> ScheduleDates()
        {
            var context = new UsersDbContext();
            return await context.Set<ScheduleDates>().ToListAsync();
        }
        [HttpGet("GetProjectProposal/{lecturerId}")]
        public async Task<ActionResult<IReadOnlyList<ProjectProposal>>> GetProjectProposal([FromRoute] long lecturerId)
        {
            var context = new UsersDbContext();
            var projectProposalsOfLecturer = new List<ProjectProposal>();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            foreach (var item in proposals)
            {
                if (item.LecturerID == lecturerId)
                    projectProposalsOfLecturer.Add(item);
            }
            return Ok(projectProposalsOfLecturer);
        }
        [HttpPut("PutLecturerConstraints")]
        
        //TODO add the lc to the table, if the lecturer already have constraints so replace with this
        //Todo if the admin change dates for presentation clear all constrains 
        
        public async Task<bool> PutLecturerConstraints([FromBody] LecturerConstraintDto details)
        {

            var context = new UsersDbContext();
            var lecturer = await context.Set<Lecturer>().Include(x => x.constraints).Where(x => x.id == details.LecturerId).FirstOrDefaultAsync();
            if (lecturer == null)
                return false;

            if(lecturer.constraints.Count> 0)
            {
                foreach (var item in lecturer.constraints)
                {
                    context.Set<LecConstraint>().Remove(item);
                }
                lecturer.constraints.Clear();
            }
                

            await context.SaveChangesAsync();
            details.Sessions1.AddRange(details.Sessions2);
            foreach (var item in details.Sessions1)
            {
                var constraint1 = new LecConstraint(item);
                var constraint2 = new LecConstraint(item + 5);
                var constraint3 = new LecConstraint(item + 10);
                var constraint4 = new LecConstraint(item + 15);
                lecturer.constraints.AddRange(new[] { constraint1, constraint2, constraint3, constraint4 });
            }
            await context.SaveChangesAsync();
            return true;
        }


        [HttpPut("SendEmailTo1Student{StudentId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Student([FromBody] EmailMessageDetails details, [FromRoute] long StudentId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var student = await context.Set<Student>().Where(x => x.id == StudentId).FirstOrDefaultAsync();
            if (student == null)
                return NotFound(false);
            var msg = "Hi, " + student.FirstName + " " + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            sender.SendEmail(EmailMessageDetails.SystemEmail, student.Email, details.Subject, msg);
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




        [HttpPut("SendEmailTo1Admin{AdminId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Admin([FromBody] EmailMessageDetails details, [FromRoute] long AdminId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var admin = await context.Set<Admin>().Where(x => x.id == AdminId).FirstOrDefaultAsync();
            if (admin == null)
                return NotFound(false);
            var msg = "Hi, " + admin.FirstName + " " + admin.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
            sender.SendEmail(EmailMessageDetails.SystemEmail, admin.Email, details.Subject, msg);
            return Ok(true);
        }

        [HttpPost("ApproveProposal{proposalId}")]
        public async Task<ActionResult<bool>> ApproveProposal([FromRoute] int proposalId)
        {
            var context = new UsersDbContext();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            var proposal = await context.Set<ProjectProposal>().Where(x => x.Id == proposalId).FirstOrDefaultAsync();
            if (proposal == null)
                return NotFound(false);
            proposal.IsApproved = true;
            await context.SaveChangesAsync();
            return Ok(true);

        }
        [HttpDelete("DenyProposal/{proposalId}")]
        public async Task<ActionResult<bool>> DenyProposal([FromRoute] int proposalId)
        {
            var context = new UsersDbContext();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            foreach (var item in proposals)
            {
                if (item.Id == proposalId)
                {
                    context.Remove(item);
                    await context.SaveChangesAsync();
                    return Ok(true);
                }
            }
            return NotFound(false);

        }

    }
}
