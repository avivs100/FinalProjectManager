// See https://aka.ms/new-console-template for more information
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;


using (var context = new PubContext())
{ 
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

SeedDb();
GetAuthors();

void SeedDb()
{
    using var context = new PubContext();
    var userType = new UserType(Guid.NewGuid(), "Admin");
    var user = User.Create(Guid.NewGuid(), "Natasha", userType);

    //context.UserTypes.Add(userType);
    context.Set<User>().Add(user);

    context.SaveChanges();
}

void GetAuthors()
{
    using var context = new PubContext();
    var users = context.Set<User>().ToList();
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}