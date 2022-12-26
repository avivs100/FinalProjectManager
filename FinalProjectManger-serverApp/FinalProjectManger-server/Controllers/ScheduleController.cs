using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Domain.DayInSchedule;
using static Domain.Schedule;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProjectManger_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        [HttpGet("GetSchedule")]
        public async Task<ActionResult<ScheduleFull>> GetSchedule()
        {
            var context = new UsersDbContext();
            var schedule = await context.Set<Schedule>().ToListAsync();
            var day1NotFull = await context.Set<DayInSchedule>().Where(x => x.Id == schedule[0].DayOneID).FirstOrDefaultAsync();
            var session1day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session1ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session2day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session2ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session3day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session3ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session4day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session4ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session5day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session5ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session6day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session6ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();

            var day1Full = new DayInScheduleFull(day1NotFull.Id, day1NotFull.FirstDay, session1day1, session2day1, session3day1, session4day1, session5day1, session6day1);

            var day2NotFull = await context.Set<DayInSchedule>().Where(x => x.Id == schedule[0].DayTwoID).FirstOrDefaultAsync();
            var session1day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session1ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session2day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session2ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session3day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session3ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session4day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session4ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session5day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session5ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session6day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session6ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            
            var day2Full = new DayInScheduleFull(day2NotFull.Id, day2NotFull.FirstDay, session1day2, session2day2, session3day2, session4day2, session5day2, session6day2);

            return Ok(new ScheduleFull(schedule[0].Id, day1Full, day2Full));


        }
    }
}
