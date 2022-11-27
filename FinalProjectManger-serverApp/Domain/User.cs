namespace Domain;

public class User
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserType? UserType { get; set; } = null;
    public bool IsLecturer { get; set; } = false;
    public int UserTypeId { get; set; }
}