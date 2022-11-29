namespace Domain;

public class User
{
    public User()
    {
        UserType = new UserType();
    }
    public string UserName { get; set; } 
    public string Password { get; set; }
    public string Email { get; set; } 
    public UserType UserType { get; set; } 
    public bool IsLecturer { get; set; } 
    public int UserTypeId { get; set; }
    public Guid Id { get; set; }
}