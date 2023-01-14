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
    //add 120 students
    for (int i = 0; i < 200; i++)
    {   
        if(i == 2)
            context.Set<Student>().Add(new Student(i, UserType.student, "Sagi", "Fishman", "1", "default@gmail.com"));
        else
            context.Set<Student>().Add(new Student(i, UserType.student, "Fname " + i, "Lname " + i, "1", "default@gmail.com"));
    }
    //add 30 lecturers
    for (int i = 0; i < 30; i++)
    {
        Lecturer tempLec;
        if (i == 4)
            tempLec = new Lecturer(i, UserType.lecturer, "Erez ", "Eres", "1", "default@gmail.com");
        else
            tempLec = new Lecturer(i, UserType.lecturer, "Fname " + i, "Lname " + i, "1", "default@gmail.com");
        var tempCon = new Random().Next(21);
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
        var tempLec = lecturers[new Random().Next(lecturers.Count)];
        context.Set<Project>().Add(new Project("Name " + i, tempLec.id, tempStudent1.id,
            tempStudent2.id, ProjectType.Research, "Code " + i));
        tempListOfStudents.Remove(tempStudent1);
        tempListOfStudents.Remove(tempStudent2);
    }
    context.SaveChanges();
    var lecForPermission = lecturers.Where(x => x.id == 2).FirstOrDefault();
    var lecForPermission2 = lecturers.Where(x => x.id == 8).FirstOrDefault();
    context.Set<Premission>().Add(new Premission(lecForPermission.id, lecForPermission.FirstName + " " + lecForPermission.LastName));
    context.Set<Premission>().Add(new Premission(lecForPermission2.id, lecForPermission2.FirstName + " " + lecForPermission2.LastName));

    var projectProposal = new ProjectProposal("Project proposal 1", ProjectType.Development, "Development because .....", "keyword1", "general description1",
        "main tools1", "planned Working Process During The First Semester1", "product of the work1", 2, 3, false, 4);

    var projectProposal2 = new ProjectProposal("Project proposal 2", ProjectType.Research, "Research because .....", "keyword2", "general description2",
    "main tools2", "planned Working Process During The First Semester2", "product of the work2", 5, 6, false, 4);

    context.Set<ProjectProposal>().Add(projectProposal);
    context.Set<ProjectProposal>().Add(projectProposal2);

    context.SaveChanges();
}