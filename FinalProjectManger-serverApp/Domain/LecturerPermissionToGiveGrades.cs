using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LecturerPermissionToGiveGrades
    {

        public long Id; // Id of Lecturer
        public List<int> PresentationGradeId;
        public List<int> BookGradeId;
        public List<int> LecturerGradeId;


        public LecturerPermissionToGiveGrades()
        {

        }

        public LecturerPermissionToGiveGrades(long lecturerId, List<int> presentationGradeId, List<int> bookGradeId, List<int> lecturerGradeId)
        {
            Id = lecturerId;
            PresentationGradeId = presentationGradeId;
            BookGradeId = bookGradeId;
            LecturerGradeId = lecturerGradeId;
        }


    }
    public class LecturerPermissionToGiveGradesFull
    {
        public Lecturer Lecturer;
        public List<PresentationGrade> PresentationGrade;
        public List<BookGrade> BookGrade;
        public List<LecturerGrade> LecturerGrade;

        public LecturerPermissionToGiveGradesFull()
        {

        }
        public LecturerPermissionToGiveGradesFull(Lecturer lecturer, List<PresentationGrade> presentationGrade, List<BookGrade> bookGrade, List<LecturerGrade> lecturerGrade)
        {
            Lecturer = lecturer;
            PresentationGrade = presentationGrade;
            BookGrade = bookGrade;
            LecturerGrade = lecturerGrade;
        }
    }
}
