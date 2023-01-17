
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
    var FnameList = new List<string>() { "David", "Ariel", "Noam", "Lavi", "Yosef", "Ori", "Uri", "Eitan ", "Daniel", "Yehuda", "Moshe", "Raphael",
        "Aharon", "Itai", "Yehonatan", "Israel", "Abraham", "Shmuel",  "Omer","Michael", "Itamar", "Yaakov", "Eliya", "Yair", "Yitzchak", "Yonatan", "Ido",
        "Ari", "Shimon", "Chaim", "Yanai", "Shlomo", "Harel","Imri",  "Elon", "Amit", "Ilay", "Meir", "Nitai","Mordechai",  "Adam","Guy", "Nehorai", "Ben",
        "Yishai", "Or", "Menachem", "Benjamin", "Liam", "Netanel", "Eliyahu", "Elroi", "Maor", "Aviv", "Roi", "Omri", "Natan","Bnaya", "Yuval", "Rom","Shachar"
        , "Nadav", "Evyatar", "Dor", "Lior", "Nevo", "Matan","Yahav","Shalom"};
    var LnameList = new List<string>() { "Hoffman", "Levi","Cohen", "Haddad", "Goldman", "Levy", "Blau", "Fridman", "Horowitz", "Abulafia", "Blum", "Kantor",
        "Cardoso", "Leiberman", "Efron", "Abutbul", "Schechter", "Bernstein", "Geller", "Melamed", "Haziza", "Lavi", "Menachem", "Meir", "Goldberg","Abu fani",
        "Ali","David", "Din", "Dolev", "Stern", "Becker", "Ackerman", "Hazan", "Altman", "Rubin", "Nahum", "Navarro", "Naftali", "Nisim", "Bach", "Alterman",
        "Abadi", "Berenson", "Cooperman", "Barak", "Diamond", "Baran", "Bark", "Belman", "Klein", "Landau", "Eisen", "Hakimi", "Katz"};
    var FirstWordToProjName = new List<string>() { "Voice-based", "Automated Robot",  "Project", "Wi-Fi Based" , "Semi-Supervised Learning", "Battery Optimizer",
        "Visual Tracking", "Sockets Programming in Python","Computer-Aided", "Elevator Control", "Web-Based", "Software Engineering", "Privacy-Preserving Data Sharing",
        "Information Flow", "Simulation and Exploration", "Band-Aids", "Mobile Apps", "A Railway Anti-collision System", "A Reverse Engineering Approach",
        "Debugging Grids", "Automated Low-Level Analysis", "3D Mobile Game", "Bug Tracking System", "Development of a Feature-Rich", "Design and Development",
        "File System", "Computer Folders", "Credit Card Reader", "Recognition of Hand Movement", "Network Security Implementation Layer","Data Mining Technique",
        };
    var SecWordToProjName = new List<string>() { "for the Blind", "for Military System", "Management System", "using Graph Kernels" , " for Android Mobile Devices",
    "Cloud-Based Storage", "with Sea Shell Effect", "Learning Tool", "system", "Library System", "of Scientific Software", "Energy & Power Efficient",
        "With Anonymous ID Assignment", "in Bargaining Scenarios", "of Hybrid Systems via Automata", "with Phis Plate Removal Sensing", "with Auto Track Changing",
        "for Converting Conventional", "with Machine Learning", "Development Software Project", "of Speed Cash System", "Using WLS Algorithms", "with Auto-Track Changing",
        "based Cheap Lie Detector", "with Face Recognition", "based on Webcam", "using Signature", "for DNS System", "for Web Services"};

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
        var tempFname = FnameList[new Random().Next(FnameList.Count)];
        var tempLname = LnameList[new Random().Next(LnameList.Count)];
        context.Set<Student>().Add(new Student(i, UserType.student, tempFname, tempLname, "1", "default@gmail.com"));
    }
    //add 30 lecturers
    for (int i = 600; i < 629; i++)
    {
        var tempFname = FnameList[new Random().Next(FnameList.Count)];
        var tempLname = LnameList[new Random().Next(LnameList.Count)];
        tempLec = new Lecturer(i, UserType.lecturer, tempFname, tempLname, "1", "default@gmail.com");
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
        var tempFirstword = FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)];
        var tempSecword = SecWordToProjName[new Random().Next(SecWordToProjName.Count)];
        var fullName = tempFirstword + " " + tempSecword;
        tempLec = lecturers[new Random().Next(lecturers.Count)];
        ProjectType tempProjType;
        if (i % 2 == 0)
            tempProjType = ProjectType.Research;
        else
            tempProjType = ProjectType.Development;
        context.Set<Project>().Add(new Project(fullName, tempLec.id, tempStudent1.id,
            tempStudent2.id, tempProjType, "Code " + i));
        tempListOfStudents.Remove(tempStudent1);
        tempListOfStudents.Remove(tempStudent2);
    }
    context.SaveChanges();
    Lecturer lecForPermission;
    for (int i = 600; i < 607; i++)
    {
        lecForPermission = lecturers.Where(x => x.id == i).FirstOrDefault();
        context.Set<Premission>().Add(new Premission(lecForPermission.id, lecForPermission.FirstName + " " + lecForPermission.LastName));
    }

    var projectProposal = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Development, "Development because .....", "keyword1", "general description1",
        "main tools1", "planned Working Process During The First Semester1", "product of the work1", 184, 186, false, 4);

    var projectProposal2 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
    "main tools2", "planned Working Process During The First Semester2", "product of the work2", 200, 238, false, 4);
    var projectProposal3 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Development, "Development because .....", "keyword1", "general description1",
        "main tools1", "planned Working Process During The First Semester1", "product of the work3", 180, 181, false, 4);

    var projectProposal4 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
        "main tools2", "planned Working Process During The First Semester2", "product of the work4", 100, 101, false, 4);

    var projectProposal5 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
    "main tools2", "planned Working Process During The First Semester2", "product of the work4", 102, 103, true, 4);

    var projectProposal6 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
"main tools2", "planned Working Process During The First Semester2", "product of the work4", 104, 105, true, 600);

    var projectProposal7 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
"main tools2", "planned Working Process During The First Semester2", "product of the work4", 120, 121, true, 601);
    var projectProposal8 = new ProjectProposal(FirstWordToProjName[new Random().Next(FirstWordToProjName.Count)] + " " + SecWordToProjName[new Random().Next(SecWordToProjName.Count)]
        , ProjectType.Research, "Research because .....", "keyword2", "general description2",
"main tools2", "planned Working Process During The First Semester2", "product of the work4", 122, 123, true, 601);


    context.Set<ProjectProposal>().Add(projectProposal);
    context.Set<ProjectProposal>().Add(projectProposal2);
    context.Set<ProjectProposal>().Add(projectProposal3);
    context.Set<ProjectProposal>().Add(projectProposal4);
    context.Set<ProjectProposal>().Add(projectProposal5);
    context.Set<ProjectProposal>().Add(projectProposal6);
    context.Set<ProjectProposal>().Add(projectProposal7);
    context.Set<ProjectProposal>().Add(projectProposal8);

    context.SaveChanges();
}