using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Protocol.Plugins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Student> students = context.Set<Student>().ToList();
        List<Lecturer> lecturers = context.Set<Lecturer>().ToList();
        List<Admin> admins = context.Set<Admin>().ToList();

        // GET: api/<LogInController>
        [HttpGet()]
        public UserType Get(long id, string Password)
        {
            var admin = admins.Find(x => x.id == id);
            if (admin != null && admin.password.Equals(Password))
                return UserType.admin;
            var lecturer = lecturers.Find(x => x.id == id);
            if (lecturer != null && lecturer.password.Equals(Password))
                return UserType.lecturer;
            var student = students.Find(x => x.id == id);
            if (student != null && student.password.Equals(Password))
                return UserType.student;
            return UserType.none;
        }
    }
}
