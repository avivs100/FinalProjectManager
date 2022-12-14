using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();
        List<Student> students = context.Set<Student>().ToList();
        List<LecturerGrade> LecturerGrades = context.Set<LecturerGrade>().ToList();
        List<PresentationGrade> PresentationGrades = context.Set<PresentationGrade>().ToList();
        List<BookGrade> BookGrades = context.Set<BookGrade>().ToList();
        List<Project> Projects = context.Set<Project>().ToList();


        [HttpGet("GetLecturerGrade")]
        public IEnumerable<LecturerGrade> GetLecturerGrade()
        {
            return LecturerGrades;
        }

        [HttpGet("GetPresentationGrade")]
        public IEnumerable<PresentationGrade> GetPresentationGrade()
        {
            return PresentationGrades;
        }

        [HttpGet("GetBookGrade")]
        public IEnumerable<BookGrade> GetBookGrade()
        {
            return BookGrades;
        }



        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GradesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GradesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
