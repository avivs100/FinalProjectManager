using System;
using System.Collections.Generic;
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
    }
}
