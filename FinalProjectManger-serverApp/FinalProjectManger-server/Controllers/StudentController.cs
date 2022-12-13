using Data;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class StudentController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Student> students = context.Set<Student>().ToList();
        // GET: api/<StudentController>
        [HttpGet("students")]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(long id)
        {
            var student = students.Find(x => x.id == id);
            return student ;
        }

        // POST api/<StudentController>
        [HttpPost] 
        public bool Post(long id, [FromBody] StudentDetails studentDetails)
        {
            if (!(students.Any(x => x.id == id)))
            {
                return false;
            }
            Student student = students.Find(x => x.id == id);
            context.Remove(student);
            context.SaveChanges();
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;
            student.password = studentDetails.password;
            context.Add(student);
            context.SaveChanges();
            return true;
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public void Put([FromBody] Student s)
        {
            Student student = new Student();
            student.id = s.id;
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            student.password = s.password;
            context.Add(student);
            context.SaveChanges();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public bool Delete(long id)
        {
            if (students.Any(x => x.id == id))
            {
                Student studentToDelete = students.Find(x => x.id == id);
                context.Remove(studentToDelete);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //[HttpGet("id-pass")]
        //public Student Get(List<object> idAndPass)
        //{
        //    var student = students.Find(x => x.id == id);
        //    return student;
        //}

    }
}
