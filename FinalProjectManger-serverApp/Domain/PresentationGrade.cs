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
        public double AverageScore { get; set; }
        public double ComputeScore()
        {
            AverageScore = Organization.Score * Organization.Precentage
                + QualityOfProblem.Score * QualityOfProblem.Precentage
                + TechnicalQuality.Score * TechnicalQuality.Precentage
                + GeneralEvaluation.Score * GeneralEvaluation.Precentage;
            return AverageScore;
        }

    }
}
