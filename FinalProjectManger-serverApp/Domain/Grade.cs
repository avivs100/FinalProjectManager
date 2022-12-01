namespace Domain;

public class Grade
{
    
    public static Grade Create(string description)
    {
        return new Grade(description);
    }
    public string Description { get; set; } = null!;
    public int Id { get; set; }

    private Grade()
    {
    }

    private Grade(string description)
    {
        Description = description;
        
    }
}