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
        public async Task<ActionResult<ScheduleFull1>> GetSchedule()
        {
            var context = new UsersDbContext();
            var sessions = await context.Set<Session>().Include(x => x.ProjectsID).ToListAsync();
            if (sessions.Count < 40)
                return NotFound();

            var classSessions1day1 = new ClassSessionsFull();
            var classSessions2day1 = new ClassSessionsFull();
            var classSessions3day1 = new ClassSessionsFull();
            var classSessions4day1 = new ClassSessionsFull();

            var classSessions1day2 = new ClassSessionsFull();
            var classSessions2day2 = new ClassSessionsFull();
            var classSessions3day2 = new ClassSessionsFull();
            var classSessions4day2 = new ClassSessionsFull();

            classSessions1day1.Session1 = sessions[0];
            classSessions1day1.Session2 = sessions[4];
            classSessions1day1.Session3 = sessions[8];
            classSessions1day1.Session4 = sessions[12];
            classSessions1day1.Session5 = sessions[16];
            classSessions1day1.ClassName = sessions[0].ClassRoom;

            classSessions2day1.Session1 = sessions[1];
            classSessions2day1.Session2 = sessions[5];
            classSessions2day1.Session3 = sessions[9];
            classSessions2day1.Session4 = sessions[13];
            classSessions2day1.Session5 = sessions[17];
            classSessions2day1.ClassName = sessions[1].ClassRoom;

            classSessions3day1.Session1 = sessions[2];
            classSessions3day1.Session2 = sessions[6];
            classSessions3day1.Session3 = sessions[10];
            classSessions3day1.Session4 = sessions[14];
            classSessions3day1.Session5 = sessions[18];
            classSessions3day1.ClassName = sessions[2].ClassRoom;

            classSessions4day1.Session1 = sessions[3];
            classSessions4day1.Session2 = sessions[7];
            classSessions4day1.Session3 = sessions[11];
            classSessions4day1.Session4 = sessions[15];
            classSessions4day1.Session5 = sessions[19];
            classSessions4day1.ClassName = sessions[3].ClassRoom;

            classSessions1day2.Session1 = sessions[20];
            classSessions1day2.Session2 = sessions[24];
            classSessions1day2.Session3 = sessions[28];
            classSessions1day2.Session4 = sessions[32];
            classSessions1day2.Session5 = sessions[36];
            classSessions1day2.ClassName = sessions[20].ClassRoom;

            classSessions2day2.Session1 = sessions[21];
            classSessions2day2.Session2 = sessions[25];
            classSessions2day2.Session3 = sessions[29];
            classSessions2day2.Session4 = sessions[33];
            classSessions2day2.Session5 = sessions[37];
            classSessions2day2.ClassName = sessions[21].ClassRoom;

            classSessions3day2.Session1 = sessions[22];
            classSessions3day2.Session2 = sessions[26];
            classSessions3day2.Session3 = sessions[30];
            classSessions3day2.Session4 = sessions[34];
            classSessions3day2.Session5 = sessions[38];
            classSessions3day2.ClassName = sessions[22].ClassRoom;

            classSessions4day2.Session1 = sessions[23];
            classSessions4day2.Session2 = sessions[27];
            classSessions4day2.Session3 = sessions[31];
            classSessions4day2.Session4 = sessions[35];
            classSessions4day2.Session5 = sessions[39];
            classSessions4day2.ClassName = sessions[23].ClassRoom;

            var dayInSchedule1 = new DayInScheduleFull1();
            dayInSchedule1.ClassSessions1 = classSessions1day1;
            dayInSchedule1.ClassSessions2 = classSessions2day1;
            dayInSchedule1.ClassSessions3 = classSessions3day1;
            dayInSchedule1.ClassSessions4 = classSessions4day1;
            dayInSchedule1.Day = false;

            var dayInSchedule2 = new DayInScheduleFull1();
            dayInSchedule2.ClassSessions1 = classSessions1day2;
            dayInSchedule2.ClassSessions2 = classSessions2day2;
            dayInSchedule2.ClassSessions3 = classSessions3day2;
            dayInSchedule2.ClassSessions4 = classSessions4day2;
            dayInSchedule2.Day = true;

            var scheduleNew = new ScheduleFull1();
            scheduleNew.DayOne = dayInSchedule1;
            scheduleNew.DayTwo = dayInSchedule2;

            return Ok(scheduleNew);
        }

        [HttpPost("GenerateSchedule")]
        public async Task<ActionResult<ScheduleFull1>> GenerateSchedule()
        {
            var context = new UsersDbContext();
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
                var projForGenetic = new TryGenetic.Project(proj.ProjectId, proj.ProjectName, proj.LecturerId, proj.student1Id, proj.student2Id, proj.gradeAId, proj.gradeBId, (TryGenetic.ProjectType)proj.ProjectType, proj.projCode);
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
            var classSessions1day1 = new ClassSessionsFull();
            var classSessions2day1 = new ClassSessionsFull();
            var classSessions3day1 = new ClassSessionsFull();
            var classSessions4day1 = new ClassSessionsFull();

            var classSessions1day2 = new ClassSessionsFull();
            var classSessions2day2 = new ClassSessionsFull();
            var classSessions3day2 = new ClassSessionsFull();
            var classSessions4day2 = new ClassSessionsFull();

            classSessions1day1.Session1 = sessions[0];
            classSessions1day1.Session2 = sessions[4];
            classSessions1day1.Session3 = sessions[8];
            classSessions1day1.Session4 = sessions[12];
            classSessions1day1.Session5 = sessions[16];
            classSessions1day1.ClassName = sessions[0].ClassRoom;

            classSessions2day1.Session1 = sessions[1];
            classSessions2day1.Session2 = sessions[5];
            classSessions2day1.Session3 = sessions[9];
            classSessions2day1.Session4 = sessions[13];
            classSessions2day1.Session5 = sessions[17];
            classSessions2day1.ClassName = sessions[1].ClassRoom;

            classSessions3day1.Session1 = sessions[2];
            classSessions3day1.Session2 = sessions[6];
            classSessions3day1.Session3 = sessions[10];
            classSessions3day1.Session4 = sessions[14];
            classSessions3day1.Session5 = sessions[18];
            classSessions3day1.ClassName = sessions[2].ClassRoom;

            classSessions4day1.Session1 = sessions[3];
            classSessions4day1.Session2 = sessions[7];
            classSessions4day1.Session3 = sessions[11];
            classSessions4day1.Session4 = sessions[15];
            classSessions4day1.Session5 = sessions[19];
            classSessions4day1.ClassName = sessions[3].ClassRoom;

            classSessions1day2.Session1 = sessions[20];
            classSessions1day2.Session2 = sessions[24];
            classSessions1day2.Session3 = sessions[28];
            classSessions1day2.Session4 = sessions[32];
            classSessions1day2.Session5 = sessions[36];
            classSessions1day2.ClassName = sessions[20].ClassRoom;

            classSessions2day2.Session1 = sessions[21];
            classSessions2day2.Session2 = sessions[25];
            classSessions2day2.Session3 = sessions[29];
            classSessions2day2.Session4 = sessions[33];
            classSessions2day2.Session5 = sessions[37];
            classSessions2day2.ClassName = sessions[21].ClassRoom;

            classSessions3day2.Session1 = sessions[22];
            classSessions3day2.Session2 = sessions[26];
            classSessions3day2.Session3 = sessions[30];
            classSessions3day2.Session4 = sessions[34];
            classSessions3day2.Session5 = sessions[38];
            classSessions3day2.ClassName = sessions[22].ClassRoom;

            classSessions4day2.Session1 = sessions[23];
            classSessions4day2.Session2 = sessions[27];
            classSessions4day2.Session3 = sessions[31];
            classSessions4day2.Session4 = sessions[35];
            classSessions4day2.Session5 = sessions[39];
            classSessions4day2.ClassName = sessions[23].ClassRoom;

            var dayInSchedule1 = new DayInScheduleFull1();
            dayInSchedule1.ClassSessions1 = classSessions1day1;
            dayInSchedule1.ClassSessions2 = classSessions2day1;
            dayInSchedule1.ClassSessions3 = classSessions3day1;
            dayInSchedule1.ClassSessions4 = classSessions4day1;
            dayInSchedule1.Day = false;

            var dayInSchedule2 = new DayInScheduleFull1();
            dayInSchedule2.ClassSessions1 = classSessions1day2;
            dayInSchedule2.ClassSessions2 = classSessions2day2;
            dayInSchedule2.ClassSessions3 = classSessions3day2;
            dayInSchedule2.ClassSessions4 = classSessions4day2;
            dayInSchedule2.Day = true;

            var scheduleNew = new ScheduleFull1();
            scheduleNew.DayOne = dayInSchedule1;
            scheduleNew.DayTwo = dayInSchedule2;

            context.Add(day1);
            context.Add(day2);
            context.Add(schedule);
            await context.SaveChangesAsync();
            return Ok(scheduleNew);
        }



        [HttpPost("RemoveLecturerFromSession/{sessionId}/{lecturerId}")]
        public async Task<ActionResult<bool>> RemoveLecturerFromSession([FromRoute] int sessionId, [FromRoute] int lecturerId)
        {
            var context = new UsersDbContext();
            var lecturer = await context.Set<Domain.Lecturer>().Where(x => x.id == lecturerId).FirstOrDefaultAsync();
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (lecturer == null || session == null)
                return NotFound(false);
            if (session.Lecturer2ID == lecturer.id)
                session.Lecturer2ID = 0;
            if (session.Lecturer3ID == lecturer.id)
                session.Lecturer3ID = 0;
            if (session.ResponsibleLecturerID == lecturer.id)
                session.ResponsibleLecturerID = 0;
            await context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("AddLecturerToSession/{sessionId}/{lecturerId}")]
        public async Task<ActionResult<bool>> AddLecturerToSession([FromRoute] int sessionId, [FromRoute] int lecturerId)
        {
            var context = new UsersDbContext();
            var lecturer = await context.Set<Domain.Lecturer>().Where(x => x.id == lecturerId).FirstOrDefaultAsync();
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (lecturer == null || session == null)
                return NotFound(false);
            if (session.Lecturer2ID == 0)
                session.Lecturer2ID = lecturerId;
            else if (session.Lecturer3ID == 0)
                session.Lecturer3ID = lecturerId;
            else if (session.ResponsibleLecturerID == 0)
                session.ResponsibleLecturerID = lecturerId;
            await context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("AddProjectToSession/{sessionId}/{projectId}")]
        public async Task<ActionResult<bool>> AddProjectToSession([FromRoute] int sessionId, [FromRoute] int projectId)
        {
            var context = new UsersDbContext();
            var project = await context.Set<Domain.Project>().Where(x => x.ProjectId == projectId).FirstOrDefaultAsync();
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).Include(x=>x.ProjectsID).FirstOrDefaultAsync();
            if (project == null || session == null)
                return NotFound(false);
            if (session.ProjectsID.Count == 6)
                return false;
            session.ProjectsID.Add(project);
            await context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPost("RemoveProjectFromSession/{sessionId}/{projectId}")]
        public async Task<ActionResult<bool>> RemoveProjectFromSession([FromRoute] int sessionId, [FromRoute] int projectId)
        {
            var context = new UsersDbContext();
            var project = await context.Set<Domain.Project>().Where(x => x.ProjectId == projectId).FirstOrDefaultAsync();
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (project == null || session == null)
                return NotFound(false);
            session.ProjectsID.Remove(project);
            await context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
