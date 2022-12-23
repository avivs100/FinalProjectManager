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

        [HttpPut("PutLecturerConstraints")]
        //TODO create with ef table for lecturer constraints and change return type to bool,
        //TODO add the lc to the table, if the lecturer already have constraints so replace with this
        //TODO create get method for this constraint by lecturer id, and also get all constraints for admin
        //TODO make this method async
        public ActionResult<LecturerConstraints> PutLecturerConstraints([FromBody] LecturerConstraintDto details)
        {
            var lc = new LecturerConstraints()
            {
                LecturerId = details.LecturerId,
                Date1Constraint = new LecturerConstraint()
                {
                    Date = details.Date1,
                    Sessions = details.Sessions1
                },
                Date2Constraint = new LecturerConstraint()
                {
                    Date = details.Date2,
                    Sessions = details.Sessions2
                }
            };
            return Ok(lc);
        }


        //[HttpPut("AddConstraint")]
        //public async Task<ActionResult<IReadOnlyList<Constraint>>> AddConstraint([FromRoute] long id, [FromBody] ConstraintDetails constraintDetails)
        //{
        //    Constraint constraint = new Constraint(constraintDetails.Year, constraintDetails.Month, constraintDetails.Day, constraintDetails.Hour, constraintDetails.Minute, constraintDetails.Second);
        //    await context.Set<Constraint>().Add(constraint);
        //}
    }
}
