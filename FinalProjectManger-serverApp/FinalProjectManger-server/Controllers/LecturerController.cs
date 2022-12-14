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
        // GET: api/<LecturerController>
        [HttpGet]
        public IEnumerable<Lecturer> Get()
        {
            return lecturers;
        }

        // GET api/<LecturerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> Get([FromRoute]long id)
        {
            var lecturer = await context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (lecturer == null) return NotFound();
            return lecturer;
        }

        // POST api/<LecturerController>
        [HttpPost]
        public bool Post(long id, [FromBody] LecturerDetails lecturerDetails)
        {
            if (!(lecturers.Any(x => x.id == id)))
            {
                return false;
            }
            Lecturer lecturer = lecturers.Find(x => x.id == id);
            context.Remove(lecturer);
            context.SaveChanges();
            lecturer.FirstName = lecturerDetails.FirstName;
            lecturer.LastName = lecturerDetails.LastName;
            lecturer.password = lecturerDetails.password;
            context.Add(lecturer);
            context.SaveChanges();
            return true;
        }

        // PUT api/<LecturerController>/5
        [HttpPut]
        public void Put(int id, [FromBody] Lecturer l)
        {
            Lecturer lecturer = new Lecturer();
            lecturer.id = l.id;
            lecturer.FirstName = l.FirstName;
            lecturer.LastName = l.LastName;
            lecturer.password = l.password;
            context.Add(lecturer);
            context.SaveChanges();
        }

        // DELETE api/<LecturerController>/5
        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            if (lecturers.Any(x => x.id == id))
            {
                Lecturer lecturerToDelete = lecturers.Find(x => x.id == id);
                context.Remove(lecturerToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
