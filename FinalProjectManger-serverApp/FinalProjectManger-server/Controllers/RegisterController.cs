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
        [HttpPut("Register")]
        public async Task<ActionResult<bool>> Put( [FromBody] DetailsForRegister detailsForRegister)
        {
            if (detailsForRegister.IsLecturer == false)
            {
                if( await context.Set<Student>().Where(x=>x.id == detailsForRegister.Id).FirstOrDefaultAsync() != null)
                    return NotFound(false);

                context.Add(new Student(detailsForRegister.Id, UserType.student, detailsForRegister.FirstName, detailsForRegister.LastName, detailsForRegister.Password, detailsForRegister.Email));
                await context.SaveChangesAsync();
                return Ok(true);
            }

            if (await context.Set<Lecturer>().Where(x => x.id == detailsForRegister.Id).FirstOrDefaultAsync() != null)
                return NotFound(false);

            context.Add(new Lecturer(detailsForRegister.Id, UserType.lecturer, detailsForRegister.FirstName, detailsForRegister.LastName, detailsForRegister.Password, detailsForRegister.Email));
            context.Add(new Premission()
            {
                LecturerId = detailsForRegister.Id,
                LecturerName = detailsForRegister.FirstName + detailsForRegister.LastName
            });
            await context.SaveChangesAsync();
            return Ok(true);
        }

    }
}
