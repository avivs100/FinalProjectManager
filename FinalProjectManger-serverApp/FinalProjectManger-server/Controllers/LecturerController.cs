using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturerController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        List<Constraint> constraints = context.Set<Constraint>().ToList();
        List<ScheduleDates> scheduleDates = context.Set<ScheduleDates>().ToList();
        // GET: api/<LecturerController>
        [HttpGet("ListLecturers")]
        public async Task<ActionResult<IReadOnlyList<Lecturer>>> ListLecturers()
        {
            return await context.Set<Lecturer>().ToListAsync();
        }

        // GET api/<LecturerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> Get([FromRoute] long id)
        {
            var lecturer = context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefault();
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
            return await context.Set<ScheduleDates>().ToListAsync();
        }
    }
}
