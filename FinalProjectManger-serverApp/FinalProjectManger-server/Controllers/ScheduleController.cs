using Data;
using Domain;
using FinalProjectManger_server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
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
            var sessions = await context.Set<Session>().Include(x => x.ProjectsForSessionID).ToListAsync();
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

            var FullSessions = new List<SessionFull>();
            foreach (var session in sessions)
            {
                 var lecturer1 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.ResponsibleLecturerID).FirstOrDefaultAsync();
                 var lecturer2 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.Lecturer2ID).FirstOrDefaultAsync();
                 var lecturer3 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.Lecturer3ID).FirstOrDefaultAsync();

                var fullprojects = new List<ProjectFull>();
                var fullProjectsInSession = new List<ProjectInSession>();
                var counter = 1;
                foreach (var proj in session.ProjectsForSessionID)
                {
                    var student1 = await context.Set<Student>().Where(x => x.id == proj.student1Id).FirstOrDefaultAsync();
                    var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
                    var lecturer = await context.Set<Domain.Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
                    var fullProj = new ProjectFull(proj.ProjectSessionId, proj.ProjectName, lecturer, student1, student2, proj.ProjectType, proj.projCode);
                    fullprojects.Add(fullProj);
                    var fullProjInSession = new ProjectInSession(fullProj, counter++);
                    fullProjectsInSession.Add(fullProjInSession);
                }


                var sessionFull = new SessionFull(session.Id, lecturer1, lecturer2, lecturer3, fullProjectsInSession, session.SessionNumber, session.ClassRoom);
                FullSessions.Add(sessionFull);
            }
            var temp = FullSessions.OrderBy(x => x.SessionNumber);
            var FullSessionsToClassSessions = temp.Reverse();
            FullSessions = FullSessionsToClassSessions.ToList();
            classSessions1day1.Session1 = FullSessions[0];
            classSessions1day1.Session2 = FullSessions[4];
            classSessions1day1.Session3 = FullSessions[8];
            classSessions1day1.Session4 = FullSessions[12];
            classSessions1day1.Session5 = FullSessions[16];
            classSessions1day1.ClassName = FullSessions[0].ClassRoom;

            classSessions2day1.Session1 = FullSessions[1];
            classSessions2day1.Session2 = FullSessions[5];
            classSessions2day1.Session3 = FullSessions[9];
            classSessions2day1.Session4 = FullSessions[13];
            classSessions2day1.Session5 = FullSessions[17];
            classSessions2day1.ClassName = FullSessions[1].ClassRoom;

            classSessions3day1.Session1 = FullSessions[2];
            classSessions3day1.Session2 = FullSessions[6];
            classSessions3day1.Session3 = FullSessions[10];
            classSessions3day1.Session4 = FullSessions[14];
            classSessions3day1.Session5 = FullSessions[18];
            classSessions3day1.ClassName = FullSessions[2].ClassRoom;

            classSessions4day1.Session1 = FullSessions[3];
            classSessions4day1.Session2 = FullSessions[7];
            classSessions4day1.Session3 = FullSessions[11];
            classSessions4day1.Session4 = FullSessions[15];
            classSessions4day1.Session5 = FullSessions[19];
            classSessions4day1.ClassName = FullSessions[3].ClassRoom;

            classSessions1day2.Session1 = FullSessions[20];
            classSessions1day2.Session2 = FullSessions[24];
            classSessions1day2.Session3 = FullSessions[28];
            classSessions1day2.Session4 = FullSessions[32];
            classSessions1day2.Session5 = FullSessions[36];
            classSessions1day2.ClassName = FullSessions[20].ClassRoom;

            classSessions2day2.Session1 = FullSessions[21];
            classSessions2day2.Session2 = FullSessions[25];
            classSessions2day2.Session3 = FullSessions[29];
            classSessions2day2.Session4 = FullSessions[33];
            classSessions2day2.Session5 = FullSessions[37];
            classSessions2day2.ClassName = FullSessions[21].ClassRoom;

            classSessions3day2.Session1 = FullSessions[22];
            classSessions3day2.Session2 = FullSessions[26];
            classSessions3day2.Session3 = FullSessions[30];
            classSessions3day2.Session4 = FullSessions[34];
            classSessions3day2.Session5 = FullSessions[38];
            classSessions3day2.ClassName = FullSessions[22].ClassRoom;

            classSessions4day2.Session1 = FullSessions[23];
            classSessions4day2.Session2 = FullSessions[27];
            classSessions4day2.Session3 = FullSessions[31];
            classSessions4day2.Session4 = FullSessions[35];
            classSessions4day2.Session5 = FullSessions[39];
            classSessions4day2.ClassName = FullSessions[23].ClassRoom;

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

            foreach (var sess in FullSessions)
            {
                if(sess.Lecturer2.id == sess.Lecturer3.id || sess.Lecturer2.id == sess.ResponsibleLecturer.id || sess.ResponsibleLecturer.id == sess.Lecturer3.id)
                {
                    Console.WriteLine();
                }
                if (sess.Projects[0].ProjectFull.ProjectId == sess.Projects[1].ProjectFull.ProjectId || sess.Projects[0].ProjectFull.ProjectId == sess.Projects[2].ProjectFull.ProjectId
                    || sess.Projects[0].ProjectFull.ProjectId == sess.Projects[3].ProjectFull.ProjectId || sess.Projects[0].ProjectFull.ProjectId == sess.Projects[5].ProjectFull.ProjectId
                    || sess.Projects[1].ProjectFull.ProjectId == sess.Projects[2].ProjectFull.ProjectId || sess.Projects[1].ProjectFull.ProjectId == sess.Projects[3].ProjectFull.ProjectId
                    || sess.Projects[1].ProjectFull.ProjectId == sess.Projects[4].ProjectFull.ProjectId || sess.Projects[1].ProjectFull.ProjectId == sess.Projects[5].ProjectFull.ProjectId
                    || sess.Projects[2].ProjectFull.ProjectId == sess.Projects[3].ProjectFull.ProjectId || sess.Projects[2].ProjectFull.ProjectId == sess.Projects[4].ProjectFull.ProjectId
                    || sess.Projects[2].ProjectFull.ProjectId == sess.Projects[5].ProjectFull.ProjectId || sess.Projects[3].ProjectFull.ProjectId == sess.Projects[4].ProjectFull.ProjectId
                    || sess.Projects[3].ProjectFull.ProjectId == sess.Projects[5].ProjectFull.ProjectId || sess.Projects[4].ProjectFull.ProjectId == sess.Projects[5].ProjectFull.ProjectId)
                {
                    Console.WriteLine();
                }
            }


            return Ok(scheduleNew);
        }

        [HttpPost("GenerateSchedule")]
        public async Task<ActionResult<ScheduleFull1>> GenerateSchedule()
        {
            var context = new UsersDbContext();
            var sessionsForCheck = await context.Set<Domain.Session>().ToListAsync();
            var projects = await context.Set<Domain.Project>().ToListAsync();
            //if(sessionsForCheck.Count> 0)
            //{
            //    foreach (var ses in sessionsForCheck)
            //    {
            //        ses.ProjectsID = null;
            //    }
            //    context.RemoveRange(sessionsForCheck);
            //    await context.SaveChangesAsync();
            //}
            //context.RemoveRange(sessionsForCheck);
            //await context.SaveChangesAsync();
            var genetic = new Genetic();
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
                var projForGenetic = new TryGenetic.Project(proj.ProjectId, proj.ProjectName, proj.LecturerId, proj.student1Id, proj.student2Id, (TryGenetic.ProjectType)proj.ProjectType, proj.projCode);
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

            var FullSessions = new List<SessionFull>();
            foreach (var session in sessions)
            {
                var lecturer1 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.ResponsibleLecturerID).FirstOrDefaultAsync();
                var lecturer2 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.Lecturer2ID).FirstOrDefaultAsync();
                var lecturer3 = await context.Set<Domain.Lecturer>().Where(x => x.id == session.Lecturer3ID).FirstOrDefaultAsync();
                var fullProjectsInSession = new List<ProjectInSession>();
                var fullprojects = new List<ProjectFull>();
                var counter = 1;
                foreach (var proj in session.ProjectsForSessionID)
                {
                    var student1 = await context.Set<Student>().Where(x => x.id == proj.student1Id).FirstOrDefaultAsync();
                    var student2 = await context.Set<Student>().Where(x => x.id == proj.student2Id).FirstOrDefaultAsync();
                    var lecturer = await context.Set<Domain.Lecturer>().Where(x => x.id == proj.LecturerId).FirstOrDefaultAsync();
                    var fullProj = new ProjectFull(proj.ProjectSessionId, proj.ProjectName, lecturer, student1, student2, proj.ProjectType, proj.projCode);
                    fullprojects.Add(fullProj);
                    var fullProjInSession = new ProjectInSession(fullProj, counter++);
                    fullProjectsInSession.Add(fullProjInSession);
                }
                var sessionFull = new SessionFull(session.Id, lecturer1, lecturer2, lecturer3, fullProjectsInSession, session.SessionNumber, session.ClassRoom);
                FullSessions.Add(sessionFull);
            }




            var classSessions1day1 = new ClassSessionsFull();
            var classSessions2day1 = new ClassSessionsFull();
            var classSessions3day1 = new ClassSessionsFull();
            var classSessions4day1 = new ClassSessionsFull();

            var classSessions1day2 = new ClassSessionsFull();
            var classSessions2day2 = new ClassSessionsFull();
            var classSessions3day2 = new ClassSessionsFull();
            var classSessions4day2 = new ClassSessionsFull();



            
            classSessions1day1.Session1 = FullSessions[0];
            classSessions1day1.Session2 = FullSessions[4];
            classSessions1day1.Session3 = FullSessions[8];
            classSessions1day1.Session4 = FullSessions[12];
            classSessions1day1.Session5 = FullSessions[16];
            classSessions1day1.ClassName = FullSessions[0].ClassRoom;

            classSessions2day1.Session1 = FullSessions[1];
            classSessions2day1.Session2 = FullSessions[5];
            classSessions2day1.Session3 = FullSessions[9];
            classSessions2day1.Session4 = FullSessions[13];
            classSessions2day1.Session5 = FullSessions[17];
            classSessions2day1.ClassName = FullSessions[1].ClassRoom;

            classSessions3day1.Session1 = FullSessions[2];
            classSessions3day1.Session2 = FullSessions[6];
            classSessions3day1.Session3 = FullSessions[10];
            classSessions3day1.Session4 = FullSessions[14];
            classSessions3day1.Session5 = FullSessions[18];
            classSessions3day1.ClassName = FullSessions[2].ClassRoom;

            classSessions4day1.Session1 = FullSessions[3];
            classSessions4day1.Session2 = FullSessions[7];
            classSessions4day1.Session3 = FullSessions[11];
            classSessions4day1.Session4 = FullSessions[15];
            classSessions4day1.Session5 = FullSessions[19];
            classSessions4day1.ClassName = FullSessions[3].ClassRoom;

            classSessions1day2.Session1 = FullSessions[20];
            classSessions1day2.Session2 = FullSessions[24];
            classSessions1day2.Session3 = FullSessions[28];
            classSessions1day2.Session4 = FullSessions[32];
            classSessions1day2.Session5 = FullSessions[36];
            classSessions1day2.ClassName = FullSessions[20].ClassRoom;

            classSessions2day2.Session1 = FullSessions[21];
            classSessions2day2.Session2 = FullSessions[25];
            classSessions2day2.Session3 = FullSessions[29];
            classSessions2day2.Session4 = FullSessions[33];
            classSessions2day2.Session5 = FullSessions[37];
            classSessions2day2.ClassName = FullSessions[21].ClassRoom;

            classSessions3day2.Session1 = FullSessions[22];
            classSessions3day2.Session2 = FullSessions[26];
            classSessions3day2.Session3 = FullSessions[30];
            classSessions3day2.Session4 = FullSessions[34];
            classSessions3day2.Session5 = FullSessions[38];
            classSessions3day2.ClassName = FullSessions[22].ClassRoom;

            classSessions4day2.Session1 = FullSessions[23];
            classSessions4day2.Session2 = FullSessions[27];
            classSessions4day2.Session3 = FullSessions[31];
            classSessions4day2.Session4 = FullSessions[35];
            classSessions4day2.Session5 = FullSessions[39];
            classSessions4day2.ClassName = FullSessions[23].ClassRoom;

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

            //context.Add(day1);
            //context.Add(day2);
            //context.Add(schedule);
            await context.SaveChangesAsync();
            return Ok(scheduleNew);
        }

        [HttpDelete("RemoveSchedule")]
        public async Task<ActionResult<bool>> RemovesSchedule()
        {
            var context = new UsersDbContext();
            var sessionsForCheck = await context.Set<Domain.Session>().ToListAsync();
            var projects = await context.Set<Domain.Project>().ToListAsync();
            if (sessionsForCheck.Count > 0)
            {
                foreach (var ses in sessionsForCheck)
                {
                    ses.ProjectsForSessionID = null;
                }
            }
            context.RemoveRange(sessionsForCheck);
            await context.SaveChangesAsync();
            return Ok(true);
        }



        [HttpDelete("RemoveLecturerFromSession/{sessionId}/{lecturerId}")]
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
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).Include(x=>x.ProjectsForSessionID).FirstOrDefaultAsync();
            if (project == null || session == null)
                return NotFound(false);
            if (session.ProjectsForSessionID.Count == 6)
                return false;
            var projForSession = new ProjectForSession(project);
            session.ProjectsForSessionID.Add(projForSession);
            await context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("RemoveProjectFromSession/{sessionId}/{projectId}")]
        public async Task<ActionResult<bool>> RemoveProjectFromSession([FromRoute] int sessionId, [FromRoute] int projectId)
        {
            var context = new UsersDbContext();
            var project = await context.Set<Domain.Project>().Where(x => x.ProjectId == projectId).FirstOrDefaultAsync();
            var session = await context.Set<Session>().Where(x => x.Id == sessionId).FirstOrDefaultAsync();
            if (project == null || session == null)
                return NotFound(false);

            var projForSession = new ProjectForSession(project);
            session.ProjectsForSessionID.Remove(projForSession);
            await context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
