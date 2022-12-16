using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();

        // PUT api/<RegisterController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> Put([FromRoute] long id, [FromBody] DetailsForRegister detailsForRegister)
        {
            var students = await context.Set<Student>().ToListAsync();
            var lecturers = await context.Set<Lecturer>().ToListAsync();
            if (id < 1)
            {
                return NotFound();
            }
            if (detailsForRegister.isLecturer == false)
            {
                if( await context.Set<Student>().Where(x=>x.id == id).FirstOrDefaultAsync() != null)
                    return NotFound();
                else
                {
                    context.Add(new Student(id, UserType.student, detailsForRegister.fName, detailsForRegister.lName, detailsForRegister.password));
                    context.SaveChanges();
                    return Ok();
                }
            }
            else
            {
                if (await context.Set<Lecturer>().Where(x => x.id == id).FirstOrDefaultAsync() != null)
                    return NotFound();
                else
                {
                    context.Add(new Lecturer(id, UserType.lecturer, detailsForRegister.fName, detailsForRegister.lName, detailsForRegister.password));
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

    }
}
