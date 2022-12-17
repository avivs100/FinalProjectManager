using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        
        // GET: api/<AdminController>
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Admin>>> ListAdmins()
        {
            return await context.Set<Admin>().ToListAsync();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin([FromRoute] long id)
        {
            var admin = await context.Set<Admin>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        [HttpPut("PutScheduleDates")]
        public async Task<ActionResult<ScheduleDates>> PutScheduleDates([FromBody] ScheduleDatesDetails details)
        {
            ScheduleDates scheduleDates = new ScheduleDates(details.date1, details.date2);
            context.Set<ScheduleDates>().Add(scheduleDates);
            context.SaveChanges();
            return Ok(scheduleDates);
        }

        [HttpGet("premissions")]
        public async Task<ActionResult<List<Premission>>> GetPremissions()
        {
            var premissions = await context.Set<Premission>().ToListAsync();
            return Ok(premissions);
        }

        [HttpPost("ApproveLecturer/{id}")]
        public async Task<ActionResult<bool>> ApproveLecturer([FromRoute] long id)
        {
            
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
            var premission = await context.Set<Premission>().Where(x => x.LecturerId == id).FirstOrDefaultAsync();
            if (premission == null) return NotFound(false);
            context.Set<Premission>().Remove(premission);
            await context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
