using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookGrade
    {
        public long Id { get; set; }

        public Grade Research;
        public Grade AnalysisAndConclusion;
        public Grade SwQuality;
        public Grade UIandAPPguides;
        public Grade Organization;
        public Grade GeneralEvaluation;
        public static double Precentage = 0.25;
        public double AverageScore { get; set; }

        public BookGrade()
        {

        }
        public double ComputeGrade()
        {
            AverageScore = Research.Score * Research.Precentage
                + AnalysisAndConclusion.Score * AnalysisAndConclusion.Precentage
                + SwQuality.Score * SwQuality.Precentage
                + UIandAPPguides.Score + UIandAPPguides.Precentage
                + Organization.Score * Organization.Precentage
                + GeneralEvaluation.Score * GeneralEvaluation.Precentage;
            return AverageScore;
        }

        public BookGrade(Grade research, Grade analysisAndConclusion, Grade swQuality, Grade uIandAPPguides, Grade organization, Grade generalEvaluation)
        {
            Id = new Random().Next();
            Research = research;
            AnalysisAndConclusion = analysisAndConclusion;
            SwQuality = swQuality;
            UIandAPPguides = uIandAPPguides;
            Organization = organization;
            GeneralEvaluation = generalEvaluation;
        }
    }
}
