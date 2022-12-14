using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        static UsersDbContext context = new UsersDbContext();

        [HttpGet("LecturerGrades")]
        public async Task<ActionResult<IReadOnlyList<LecturerGrade>>> LecturerGrades()
        {
            return await context.Set<LecturerGrade>().ToListAsync();
        }

        [HttpGet("BookGrades")]
        public async Task<ActionResult<IReadOnlyList<BookGrade>>> BookGrades()
        {
            return await context.Set<BookGrade>().ToListAsync();
        }
        [HttpGet("PresentationGrades")]
        public async Task<ActionResult<IReadOnlyList<PresentationGrade>>> PresentationGrades()
        {
            return await context.Set<PresentationGrade>().ToListAsync();
        }

    }
}
