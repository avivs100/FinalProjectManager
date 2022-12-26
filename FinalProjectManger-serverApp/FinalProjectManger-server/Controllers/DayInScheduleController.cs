using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Domain.DayInSchedule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayInScheduleController : ControllerBase
    {
        // GET: api/<ProjectController>
        [HttpGet("GetFullDayInSchedule")]
        public async Task<ActionResult<IReadOnlyList<DayInScheduleFull>>> GetFullDayInSchedule()
        {
            var context = new UsersDbContext();
            var dayInSchedules = await context.Set<DayInSchedule>().ToListAsync();
            var fullDayInSchedules = new List<DayInScheduleFull>();
            foreach (var day in dayInSchedules)
            {
                var session1 = await context.Set<Session>().Where(x => x.Id == day.Session1ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                var session2 = await context.Set<Session>().Where(x => x.Id == day.Session2ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                var session3 = await context.Set<Session>().Where(x => x.Id == day.Session3ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                var session4 = await context.Set<Session>().Where(x => x.Id == day.Session4ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                var session5 = await context.Set<Session>().Where(x => x.Id == day.Session5ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                var session6 = await context.Set<Session>().Where(x => x.Id == day.Session6ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
                
                var dayInScheduleFull = new DayInScheduleFull(day.Id, day.FirstDay, session1, session2, session3, session4, session5, session6);
                fullDayInSchedules.Add(dayInScheduleFull);
            }
            return fullDayInSchedules;
        }
    }
}
