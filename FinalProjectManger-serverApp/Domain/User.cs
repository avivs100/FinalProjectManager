namespace Domain;

public class User
{
    public static User Create(Guid id, string name, UserType type)
    {
        return new User(id, name, type.Id, type);
    }

    public User()
    {
    }

    public User(Guid id, string name, Guid typeId, UserType type)
    {
        Id = id;
        Name = name;
        TypeId = typeId;
        Type = type;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TypeId { get; set; }
    public UserType Type { get; set; } = null!;
}