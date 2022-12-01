namespace Domain;

public class Grade
{
    
    public static Grade Create(string description)
    {
        return new Grade(description);
    }
    public string Description { get; set; } = null!;
    public int Id { get; set; }
    public int Score { get; set; }
    public int Precentage { get; set; }
    public string Name { get; set; }


    private Grade()
    {
    }

    private Grade(string description)
    {
        Description = description;
        
    }
}