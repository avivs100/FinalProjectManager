using Domain;
using Microsoft.CodeAnalysis;
using TryGenetic;

namespace FinalProjectManger_server.Services
{
    public class ScheduleService
    {

        public Session ConvertToSession(Gene gene)
        {
            var listOfProjects = ConvertToProject(gene.Projects);

            var session = new Session(gene.Lec1.id, gene.Lec2.id, gene.Lec3.id, listOfProjects, gene.SessionNum);
            return session;
        }
        public DayInSchedule CreateDayInSchedule(bool firstDay, List<Session> sessions)
        {
            var dayInSchedule = new DayInSchedule(firstDay, sessions[0].Id, sessions[1].Id, sessions[2].Id, sessions[3].Id, sessions[4].Id);
            return dayInSchedule;
        }

        public List<Domain.Project> ConvertToProject(List<TryGenetic.Project> projs)
        {
            var listOfProjects = new List<Domain.Project>();
            foreach (var proj in projs)
            {
                var newProj = new Domain.Project(proj.ProjectName, proj.LecturerId, proj.student1Id, proj.student2Id, proj.gradeAId, proj.gradeBId, (Domain.ProjectType)proj.ProjectType, proj.projCode);
                listOfProjects.Add(newProj);
            }
            return listOfProjects;
        }


    }
}
