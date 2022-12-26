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
            return await context.Set<Lecturer>().ToListAsync();
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

        [HttpPut("SendEmailTo1Student{StudentId}")]
        public async Task<ActionResult<bool>> SendEmailTo1Student([FromBody] EmailMessageDetails details, [FromRoute] long StudentId)
        {
            EmailService sender = new EmailService();
            var context = new UsersDbContext();
            var student = await context.Set<Student>().Where(x => x.id == StudentId).FirstOrDefaultAsync();
            if (student == null)
                return NotFound(false);
            var msg = "Hi, " + student.FirstName + student.LastName + "\n" + details.Message + "\n" + "From: " + details.From;
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

        [HttpGet("GetProjectProposal/{lecturerId}")]
        public async Task<ActionResult<IReadOnlyList<ProjectProposal>>> GetProjectProposal([FromRoute] long lecturerId)
        {
            var context = new UsersDbContext();
            var projectProposalsOfLecturer = new List<ProjectProposal>();
            var proposals = await context.Set<ProjectProposal>().ToListAsync();
            foreach (var item in proposals)
            {
                if (item.LecturerID== lecturerId)
                    projectProposalsOfLecturer.Add(item);
            }
            return Ok(projectProposalsOfLecturer);
        }

        [HttpPost("ApproveProposal{proposalId}")]
        public async Task<ActionResult<bool>> ApproveProposal([FromRoute] int proposalId)
        {
            var context = new UsersDbContext();
            var proposal = await context.Set<ProjectProposal>().Where(x => x.Id == proposalId).FirstOrDefaultAsync();
            if (proposal == null)
                return NotFound(false);
            proposal.IsApproved = true;

            Project project = new Project();
            var gradeA = new GradeA();
            var gradeB = new GradeB();
            context.Add(gradeA);
            context.Add(gradeB);
            project.gradeAId = gradeA.gradeAid;
            project.gradeBId = gradeB.gradeBid;
            project.LecturerId = proposal.LecturerID;
            project.ProjectName = proposal.ProjectName;
            project.ProjectType = proposal.ProjectType;
            project.student1Id = proposal.Student1ID;
            project.student2Id= proposal.Student2ID;
            context.Add(project);
            await context.SaveChangesAsync();
            return Ok(true);

        }
    }
}
