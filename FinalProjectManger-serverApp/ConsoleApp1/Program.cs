
// See https://aka.ms/new-console-template for more information
using Data;
using Domain;



using (var context = new UsersDbContext())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}

SeedDb();


void SeedDb()
{
    using var context = new UsersDbContext();
    //add Sagi 
    context.Set<Student>().Add(new Student(2, UserType.student, "Sagi", "Fishman", "1", "sagifishman1@gmail.com"));
    //add Erez 
    var tempLec = new Lecturer(4, UserType.lecturer, "Erez ", "Eres", "1", "sagifishman1@gmail.com");
    tempLec.IsActive= true;
    var tempCon = new Random().Next(21);
    tempLec.constraints.Add(new LecConstraint(tempCon));
    tempLec.constraints.Add(new LecConstraint(tempCon + 5));
    tempLec.constraints.Add(new LecConstraint(tempCon + 10));
    tempLec.constraints.Add(new LecConstraint(tempCon + 15));
    context.Set<Lecturer>().Add(tempLec);
    //add 120 students
    for (int i = 100; i < 299; i++)
    {
        context.Set<Student>().Add(new Student(i, UserType.student, "Fname " + i, "Lname " + i, "1", "default@gmail.com"));
    }
    //add 30 lecturers
    for (int i = 600; i < 629; i++)
    {

        tempLec = new Lecturer(i, UserType.lecturer, "Fname " + i, "Lname " + i, "1", "default@gmail.com");
        tempCon = new Random().Next(21);
        tempLec.constraints.Add(new LecConstraint(tempCon));
        tempLec.constraints.Add(new LecConstraint(tempCon + 5));
        tempLec.constraints.Add(new LecConstraint(tempCon + 10));
        tempLec.constraints.Add(new LecConstraint(tempCon + 15));
        context.Set<Lecturer>().Add(tempLec);
    }
    //add admin
    var Naomi = new Admin(7, UserType.admin, "Naomi", "Onklus", "1", "sagifishman1@gmail.com");
    context.Set<Admin>().Add(Naomi);
    context.SaveChanges();


    var lecturers = context.Set<Lecturer>().ToList();
    var students = context.Set<Student>().ToList();
    var tempListOfStudents = students;

    //add 60 projects
    for (int i = 0; i < 100; i++)
    {
        var tempStudent1 = tempListOfStudents[new Random().Next(tempListOfStudents.Count)];
        var tempStudent2 = tempListOfStudents[new Random().Next(tempListOfStudents.Count)];
        tempLec = lecturers[new Random().Next(lecturers.Count)];
        context.Set<Project>().Add(new Project("Name " + i, tempLec.id, tempStudent1.id,
            tempStudent2.id, ProjectType.Research, "Code " + i));
        tempListOfStudents.Remove(tempStudent1);
        tempListOfStudents.Remove(tempStudent2);
    }
    context.SaveChanges();
    var lecForPermission = lecturers.Where(x => x.id == 4).FirstOrDefault();
    context.Set<Premission>().Add(new Premission(lecForPermission.id, lecForPermission.FirstName + " " + lecForPermission.LastName));

    var projectProposal = new ProjectProposal("Project proposal 1", ProjectType.Development, "Development because .....", "keyword1", "general description1",
        "main tools1", "planned Working Process During The First Semester1", "product of the work1", 2, 3, false, 4);

    var projectProposal2 = new ProjectProposal("Project proposal 2", ProjectType.Research, "Research because .....", "keyword2", "general description2",
    "main tools2", "planned Working Process During The First Semester2", "product of the work2", 5, 6, false, 4);

    context.Set<ProjectProposal>().Add(projectProposal);
    context.Set<ProjectProposal>().Add(projectProposal2);

    context.SaveChanges();
}