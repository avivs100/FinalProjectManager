// See https://aka.ms/new-console-template for more information
using Data;

using (PubContext context = new PubContext())
{
    context.Database.EnsureCreated();
}

GetAuthors();

void GetAuthors()
{
    using var context = new PubContext();
    var users = context.Users.ToList();
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}