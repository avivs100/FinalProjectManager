using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Student> students = context.Set<Student>().ToList();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public bool Put([FromRoute] long id, [FromBody] DetailsForRegister detailsForRegister)
        {
            if (id < 1)
            {
                return false;
            }
            if (detailsForRegister.isLecturer == false)
            {
                if(students.Any(x=>x.id == id))
                    return false;
                else
                {
                    context.Add(new Student(id, UserType.student, detailsForRegister.fName, detailsForRegister.lName, detailsForRegister.password));
                    context.SaveChanges();
                    return true;
                }
            }
            else
            {
                if (lecturers.Any(x => x.id == id))
                    return false;
                else
                {
                    context.Add(new Lecturer(id, UserType.lecturer, detailsForRegister.fName, detailsForRegister.lName, detailsForRegister.password));
                    context.SaveChanges();
                    return true;
                }
            }
        }

    }
}
