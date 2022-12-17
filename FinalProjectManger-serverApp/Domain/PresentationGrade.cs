using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PresentationGrade
    {
        public int Id { get; set; }
        public Grade Organization { get; set; }
        public Grade QualityOfProblem { get; set; }
        public Grade TechnicalQuality { get; set; }
        public Grade GeneralEvaluation { get; set; }
        public string AdditionalComment { get; set; }
        public static double Precentage = 0.25;
        public double AverageScore { get; set; } = 0;

        public double ComputeScore()
        {
            AverageScore = Organization.Score * Organization.Precentage
                + QualityOfProblem.Score * QualityOfProblem.Precentage
                + TechnicalQuality.Score * TechnicalQuality.Precentage
                + GeneralEvaluation.Score * GeneralEvaluation.Precentage;
            return AverageScore;
        }

        public PresentationGrade()
        {
            Id = new Random().Next();
            Organization = new Grade(0.25,"Organization");
            QualityOfProblem = new Grade(0.25, "Quality Of Problem");
            TechnicalQuality = new Grade(0.25, "Technical Quality");
            GeneralEvaluation = new Grade(0.25, "General Evaluation");
            AdditionalComment = "";
        }

        public PresentationGrade(Grade organization, Grade qualityOfProblem, Grade technicalQuality, Grade generalEvaluation
            ,string additionalComment)
        {
            Id = new Random().Next();
            Organization = organization;
            QualityOfProblem = qualityOfProblem;
            GeneralEvaluation = generalEvaluation;
            AdditionalComment = additionalComment;
            TechnicalQuality = technicalQuality;
        }

    }
}
