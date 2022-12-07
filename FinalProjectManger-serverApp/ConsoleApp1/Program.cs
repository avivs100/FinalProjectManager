// See https://aka.ms/new-console-template for more information
using Data;
using Domain;



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
    var userType = new UserType(Guid.NewGuid(), "Admin");
    var user = User.Create(Guid.NewGuid(), "Natasha", userType);
    var userType2 = new UserType(Guid.NewGuid(), "Lecturer");
    var user2 = User.Create(Guid.NewGuid(), "Sagi", userType2);
    var userType3 = new UserType(Guid.NewGuid(), "Student");
    var user3 = User.Create(Guid.NewGuid(), "Aviv", userType3);
    //context.UserTypes.Add(userType);
    context.Set<User>().Add(user);
    context.Set<User>().Add(user2);
    context.Set<User>().Add(user3);
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

void AddUsers(UsersDbContext context)
{

}