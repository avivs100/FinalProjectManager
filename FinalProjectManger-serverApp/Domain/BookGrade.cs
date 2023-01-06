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
        public int Id { get; set; }

        public Grade Research;
        public Grade AnalysisAndConclusion;
        public Grade SwQuality;
        public Grade UIandAPPguides;
        public Grade Organization;
        public Grade GeneralEvaluation;
        public static double Precentage = 0.25;
        public double AverageScore { get; set; } = 0;

        public BookGrade()
        {
            Id = new Random().Next();
            Research = new Grade(0.25,"Research");
            AnalysisAndConclusion = new Grade(0.15, "Analysis And Conclusion");
            SwQuality = new Grade(0.15, "Sw Quality");
            UIandAPPguides = new Grade(0.15, "UI and APP guides");
            Organization = new Grade(0.15, "Organization");
            GeneralEvaluation = new Grade(0.15, "General Evaluation");
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
