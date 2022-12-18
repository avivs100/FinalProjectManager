namespace Domain;

public class Premission
{
    public Guid Id { get; set; } 
    public long LecturerId { get; set; }
    public string LecturerName { get; set; } = null!;

    public Premission(long lecturerId, string lecturerName)
    {
        Id = Guid.NewGuid();
        LecturerId = lecturerId;
        LecturerName = lecturerName;
    }
}