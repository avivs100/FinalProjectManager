using Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StudentController : ControllerBase
    {
        
        
        // GET: api/<StudentController>
        [HttpGet("students")]
        public IEnumerable<Student> Get()
        {
            var context = new UsersDbContext();
            return context.Set<Student>().ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get([FromRoute]long id)
        {
            var context = new UsersDbContext();
            var student = await context.Set<Student>().Where(x => x.id == id).FirstOrDefaultAsync();
            if (student == null) return NotFound();
            return Ok(student) ;
        }

        // POST api/<StudentController>
        [HttpPost("{id}")] 
        public async Task<ActionResult<bool>> Post([FromRoute]long id, [FromBody] StudentDetails studentDetails)
        {
            var context = new UsersDbContext();
            var students = context.Set<Student>().ToList();
            if (!(students.Any(x => x.id == id)))
            {
                return NotFound(false);
            }
            var student = students.Find(x => x.id == id);
            context.Remove(student);
            await context.SaveChangesAsync();
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;
            student.password = studentDetails.password;
            context.Add(student);
            await context.SaveChangesAsync();
            return true;
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async void Put([FromRoute] long id, [FromBody] StudentDetails s)
        {
            var context = new UsersDbContext();
            var student = new Student
            {
                id = id,
                FirstName = s.FirstName,
                LastName = s.LastName,
                password = s.password
            };
            context.Add(student);
            await context.SaveChangesAsync();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute]long id)
        {
            var context = new UsersDbContext();
            var students = context.Set<Student>().ToList();
            if (students.All(x => x.id != id)) return NotFound(false);
            {
                var studentToDelete = students.FirstOrDefault(x => x.id == id);
                if (studentToDelete != null) return NotFound(false);
                context.Remove(studentToDelete);
                await context.SaveChangesAsync();
                return true;
            }
        }

        //[HttpGet("id-pass")]
        //public Student Get(List<object> idAndPass)
        //{
        //    var student = students.Find(x => x.id == id);
        //    return student;
        //}

    }
}
