using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectProposal
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public ProjectType ProjectType { get; set; }
        public string ProjectCategoryExplain { get; set; } // why it is research/dev
        public string Keywords { get; set; }
        public string GeneralDescriptionOfTheProblem  { get; set; }
        public string MainToolsThatWillBeUsedForSolvingTheProblem { get; set; }
        public string PlannedWorkingProcessDuringTheFirstSemester { get; set; }
        public string ProductOfTheWorkOfTheFirstSemester { get; set; }
        public long Student1ID { get; set; }
        public long Student2ID { get; set; }
        public bool IsApproved { get; set; } = false;
        public long LecturerID { get; set; }
        public ProjectProposal()
        {
            Id = new Random().Next();
        }
        public ProjectProposal(string projectName, ProjectType projectType, string projectCategoryExplain, string keywords, string generalDescriptionOfTheProblem, string mainToolsThatWillBeUsedForSolvingTheProblem, string plannedWorkingProcessDuringTheFirstSemester, string productOfTheWorkOfTheFirstSemester, long student1ID, long student2ID, bool isApproved, long lecturerID)
        {
            Id = new Random().Next();
            ProjectName = projectName;
            ProjectType = projectType;
            ProjectCategoryExplain = projectCategoryExplain;
            Keywords = keywords;
            GeneralDescriptionOfTheProblem = generalDescriptionOfTheProblem;
            MainToolsThatWillBeUsedForSolvingTheProblem = mainToolsThatWillBeUsedForSolvingTheProblem;
            PlannedWorkingProcessDuringTheFirstSemester = plannedWorkingProcessDuringTheFirstSemester;
            ProductOfTheWorkOfTheFirstSemester = productOfTheWorkOfTheFirstSemester;
            Student1ID = student1ID;
            Student2ID = student2ID;
            IsApproved = isApproved;
            LecturerID = lecturerID;
        }


    }

    public class ProjectProposalDetails
    {
        public string ProjectName { get; set; }
        public ProjectType ProjectType { get; set; }
        public string ProjectCategoryExplain { get; set; } // why it is research/dev
        public string Keywords { get; set; }
        public string GeneralDescriptionOfTheProblem { get; set; }
        public string MainToolsThatWillBeUsedForSolvingTheProblem { get; set; }
        public string PlannedWorkingProcessDuringTheFirstSemester { get; set; }
        public string ProductOfTheWorkOfTheFirstSemester { get; set; }
        public long Student1ID { get; set; }
        public long Student2ID { get; set; }
        public long LecturerID { get; set; }
    }
}
