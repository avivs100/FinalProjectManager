namespace Domain;

public class User
{
    public static User Create(long id, string name, Permission permission)
    {
        return new User(id, name, permission);
    }

    public User()
    {
    }

    public User(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public User(long id, string name, Permission permission)
    {
        Id = id;
        Name = name;
        Permission = permission;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public Permission Permission { get; set; }
}