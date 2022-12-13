using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Constraint> constraints = context.Set<Constraint>().ToList();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        // GET: api/<ConstraintController>
        [HttpGet]
        public IEnumerable<Constraint> Get()
        {
            return constraints;
        }

        // POST api/<ConstraintController>
        [HttpPost("{lecturerID}")]
        public bool Post([FromRoute] long lecturerID, [FromBody] ConstraintDetails constraint)
        {
            var lecturer = lecturers.Find(x => x.id== lecturerID);
            if (lecturer == null) return false;
            var constraintToAdd = new Constraint(constraint.Year, constraint.Month, constraint.Day, constraint.Hour, constraint.Minute, constraint.Second);
            lecturer.constraints.Add(constraintToAdd);
            constraints.Add(constraintToAdd);
            context.SaveChanges();
            return true;
        }

        // DELETE api/<ConstraintController>/5
        [HttpDelete("{lecturerID}")]
        public bool Delete([FromRoute]int lecturerID, [FromBody] Guid constraintID)
        {
            var lecturer = lecturers.Find(x => x.id == lecturerID);
            if (lecturer == null) return false;
            var conToDel = constraints.Find(x => x.id == constraintID);
            if (conToDel == null) return false;
            lecturer.constraints.Remove(conToDel);
            constraints.Remove(conToDel);
            context.SaveChanges();
            return true;
        }
    }
}
