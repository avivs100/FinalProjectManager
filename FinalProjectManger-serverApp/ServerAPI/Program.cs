using Data;
using Domain;

var builder = WebApplication.CreateBuilder(args);
using (var context = new UsersDbContext())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
}

SeedDb();
GetAuthors();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedDb()
{
    using var context = new UsersDbContext();
    var user = User.Create(203639869, "Aviv", Permission.Admin);
    var user3 = User.Create(205736226, "Sagi", Permission.Lecturer);
    List<User> users = new List<User>();
    users.Add(user);
    users.Add(user3);
    context.Set<User>().AddRange(users);
    context.SaveChanges();
}

void GetAuthors()
{
    //using var context = new UsersDbContext();
    //var users = context.Set<User>().ToList();
    //foreach (var user in users)
    //{
    //    Console.WriteLine(user);
    //}
}
