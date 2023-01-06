using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class LecturerConstraint
{
    public DateTime Date { get; set; }
    [NotMapped]
    public List<int> Sessions { get; set; } = new();

    public LecturerConstraint()
    {
    }

    public LecturerConstraint(DateTime date, List<int> sessions)
    {
        Date = date;
        Sessions = sessions;
    }
}

public class LecturerConstraints
{
    public long LecturerId { get; set; }
    public LecturerConstraint Date1Constraint { get; set; }
    public LecturerConstraint Date2Constraint { get; set; }

    public LecturerConstraints(LecturerConstraint date1, LecturerConstraint date2, long lecturerId)
    {
        LecturerId = lecturerId;
        Date1Constraint = date1;
        Date2Constraint = date2;
    }

    public LecturerConstraints()
    {

    }
}

public class LecturerConstraintDto
{
    public long LecturerId { get; set; }
    public List<int> Sessions1 { get; set; } = new();
    public List<int> Sessions2 { get; set; } = new();
}