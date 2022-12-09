// See https://aka.ms/new-console-template for more information
using Data;
using Domain;



using (var context = new UsersDbContext())
{ 
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

SeedDb();
//GetAuthors();

void SeedDb()
{
    using var context = new UsersDbContext();
    var Natasha = new Student(1, UserType.student, "Natasha", "ABC", "1");
    var Sagi = new Student(2, UserType.student, "Sagi", "Fishman", "1");
    var Aviv = new Student(3, UserType.student, "Aviv", "GayBa", "1");
    context.Set<Student>().Add(Natasha);
    context.Set<Student>().Add(Sagi);
    context.Set<Student>().Add(Aviv);

    var Erez = new Lecturer(4, UserType.lecturer, "Erez", "Eres", "1");    
    Erez.constraints.Add(new Constraint(2022, 12, 9, 13, 22, 45));
    Erez.constraints.Add(new Constraint(2022, 12, 9, 16, 15, 33));
    var Ohad = new Lecturer(5, UserType.lecturer, "Ohad", "Hahaham", "1");
    Ohad.constraints.Add(new Constraint(2022, 11, 4, 7, 55, 34));
    Ohad.constraints.Add(new Constraint(2022, 9, 2, 19, 15, 52));
    var Meni = new Lecturer(6, UserType.lecturer, "Meni", "Shit", "1");
    Meni.constraints.Add(new Constraint(2022, 4, 2, 5, 31, 17));
    Meni.constraints.Add(new Constraint(2022, 8, 8, 18, 8, 8));
    context.Set<Lecturer>().Add(Erez);
    context.Set<Lecturer>().Add(Ohad);
    context.Set<Lecturer>().Add(Meni);

    var Naomi = new Admin(7, UserType.admin, "Naomi", "Onklus", "1");
    context.Set<Admin>().Add(Naomi);

    //var Project1 = new Project("Project Management", Erez, Sagi, Aviv);
    //context.Set<Project>().Add(Project1);

    context.SaveChanges();
}

//void GetAuthors()
//{
//    using var context = new UsersDbContext();
//    var users = context.Set<User>().ToList();
//    foreach (var user in users)
//    {
//        Console.WriteLine(user);
//    }
//}