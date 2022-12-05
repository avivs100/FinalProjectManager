// See https://aka.ms/new-console-template for more information
using Data;
using Domain;
Console.WriteLine("");


using (var context = new UsersDbContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

SeedDb();
GetAuthors();

void SeedDb()
{
    using var context = new UsersDbContext();
    
    var user = User.Create(20, "Natasha",0);

    //context.UserTypes.Add(userType);
    context.Set<User>().Add(user);

    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new UsersDbContext();
    var users = context.Set<User>().ToList();
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}