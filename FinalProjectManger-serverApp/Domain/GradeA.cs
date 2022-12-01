using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GradeA
    {
        PresentationGrade presentationGrade { get; set; }
        BookGrade bookGrade { get; set; }
        LecturerGrade lecturerGrade { get; set; }
        int AverageScore { get; set; }
    }
}
