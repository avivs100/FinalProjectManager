using Data;
using Domain;
using FinalProjectManger_server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using TryGenetic;
using static Domain.DayInSchedule;
using static Domain.Schedule;
using static Domain.Session;

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
            if (schedule.Count == 0)
                return NotFound();
            var day1NotFull = await context.Set<DayInSchedule>().Where(x => x.Id == schedule[0].DayOneID).FirstOrDefaultAsync();
            var session1day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session1ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session2day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session2ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session3day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session3ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session4day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session4ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session5day1 = await context.Set<Session>().Where(x => x.Id == day1NotFull.Session5ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();

            var day1Full = new DayInScheduleFull(day1NotFull.Id, day1NotFull.FirstDay, session1day1, session2day1, session3day1, session4day1, session5day1);

            var day2NotFull = await context.Set<DayInSchedule>().Where(x => x.Id == schedule[0].DayTwoID).FirstOrDefaultAsync();
            var session1day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session1ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session2day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session2ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session3day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session3ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session4day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session4ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var session5day2 = await context.Set<Session>().Where(x => x.Id == day2NotFull.Session5ID).Include(x => x.ProjectsID).FirstOrDefaultAsync();
            var day2Full = new DayInScheduleFull(day2NotFull.Id, day2NotFull.FirstDay, session1day2, session2day2, session3day2, session4day2, session5day2);
            return Ok(new ScheduleFull(schedule[0].Id, day1Full, day2Full));
        }

        [HttpPost("GenerateSchedule")]
        public async Task<ActionResult<Schedule>> GenerateSchedule()
        {
            var context = new UsersDbContext();
            var schedule1 = await context.Set<Schedule>().ToListAsync();

            if (schedule1.Count != 0)
            {
                context.Set<Schedule>().RemoveRange(schedule1);
                var sessions1 = await context.Set<Session>().ToListAsync();
                context.Set<Session>().RemoveRange(sessions1);
                var dayInSchedules1 = await context.Set<DayInSchedule>().ToListAsync();
                context.Set<DayInSchedule>().RemoveRange(dayInSchedules1);
                await context.SaveChangesAsync();
            }
            var genetic = new Genetic();
            var projects = await context.Set<Domain.Project>().ToListAsync();
            var lecturers = await context.Set<Domain.Lecturer>().Include(x => x.constraints).ToListAsync();
            var cons = await context.Set<LecConstraint>().ToListAsync();
            var lecturersForGenetic = new List<TryGenetic.Lecturer>();
            foreach (var lec in lecturers)
            {
                var conList = new List<int>();
                foreach (var con in lec.constraints)
                {
                    conList.Add(con.SessionNumber);
                }
                var lecturerForGenetic = new TryGenetic.Lecturer(lec.id, conList);
                lecturersForGenetic.Add(lecturerForGenetic);
            }
            var projectsForGenetic = new List<TryGenetic.Project>();
            foreach (var proj in projects)
            {
                var projForGenetic = new TryGenetic.Project(proj.ProjectId, proj.LecturerId);
                projectsForGenetic.Add(projForGenetic);
            }
            genetic.CreatePopulation(lecturersForGenetic, projectsForGenetic);
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < genetic.Solutions.Count; j++)
                {
                    genetic.Fitness(genetic.Solutions[j]);
                }
                genetic.Selection();
                System.Diagnostics.Debug.WriteLine("index: " + i + " Score: " + genetic.Solutions[0].fitnessScore);
                if (genetic.Solutions[0].fitnessScore >= 10 - 10 * genetic.Treshold)
                    break;
                genetic.CrossOver();
            }
            var bestSolution = genetic.Solutions[0];
            var scheduleService = new ScheduleService();
            var sessions = new List<Session>();
            foreach (var item in bestSolution.genes)
            {
                sessions.Add(scheduleService.ConvertToSession(item));
            }
            var day1 = scheduleService.CreateDayInSchedule(true, sessions.Take(sessions.Count / 2).ToList());
            sessions.Reverse();
            var day2 = scheduleService.CreateDayInSchedule(false, sessions.Take(sessions.Count / 2).ToList());
            var schedule = new Schedule(day1.Id, day2.Id);
            foreach (var session in sessions)
            {
                context.Add(session);
            }
            context.Add(day1);
            context.Add(day2);
            context.Add(schedule);
            await context.SaveChangesAsync();
            return Ok(schedule);
        }


        //public List<ClassSessions> CreateClassSessions(List<Session> sessions)
        //{
        //    var classSessions1List = new List<ClassSessions>();
        //    var classSessions = new ClassSessions();
        //    foreach (var session in sessions)
        //    {
        //        if (session.ClassRoom == ClassRoomNames.ClassRoom1Name)
        //        {
        //            if (classSessions.Session1Id == 0)
        //                classSessions.Session1Id = session.Id;
        //            else if (classSessions.Session2Id == 0)
        //                classSessions.Session2Id = session.Id;
        //            else if (classSessions.Session3Id == 0)
        //                classSessions.Session3Id = session.Id;
        //            else
        //                classSessions.Session4Id = session.Id;
        //            classSessions1List.Add(classSessions);
        //        }
        //    }
        //    return classSessions1List;
        //}
    }
}
