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
    //var Natasha = new Student(1, UserType.student, "Natasha", "ABC", "1","sagifishman1@gmail.com");
    //var Sagi = new Student(2, UserType.student, "Sagi", "Fishman", "1", "sagifishman1@gmail.com");
    //var Aviv = new Student(3, UserType.student, "Aviv", "GayBa", "1", "avivshichman@gmail.com" );
    //var itay = new Student(11, UserType.student, "Itay", "ABC", "1", "FinalProjectManager@outlook.com");
    //var lital = new Student(8, UserType.student, "Lital", "Fishman", "1", "default@gmail.com");
    //var yaron = new Student(9, UserType.student, "Yaron", "Cohen", "1", "default@gmail.com");
    //var david = new Student(10, UserType.student, "David", "Levi", "1", "default@gmail.com");
    //var shlomi = new Student(1114, UserType.student, "shlomi", "Ashkenazi", "1", "default@gmail.com");
    //var marom = new Student(12, UserType.student, "marom", "Muhamad", "1", "default@gmail.com");
    //var Menahem = new Student(13, UserType.student, "Yaron", "Argaz", "1", "default@gmail.com");
    //var Meshulam = new Student(14, UserType.student, "David", "Kesef", "1", "default@gmail.com");
    //var Benny = new Student(15, UserType.student, "Benny", "Kise", "1", "default@gmail.com");
    //var Munitz = new Student(16, UserType.student, "Munitz", "Shulhan", "1", "default@gmail.com");
    //var messi = new Student(17, UserType.student, "Messi", "Kise", "1", "default@gmail.com");
    //var hameleh = new Student(18, UserType.student, "King", "Shulhan", "1", "default@gmail.com");
    //var NoProjStudent = new Student(20, UserType.student, "Name Of No Proj", "Shulhan", "1", "default@gmail.com");
    for (int i = 0; i < 120; i++)
    {   
        context.Set<Student>().Add(new Student(i, UserType.student, "FirstName " + i, "LastName " + i, "1", "default@gmail.com"));
    }
    //context.Set<Student>().Add(Natasha);
    //context.Set<Student>().Add(Sagi);
    //context.Set<Student>().Add(Aviv);
    //context.Set<Student>().Add(itay);
    //context.Set<Student>().Add(lital);
    //context.Set<Student>().Add(david);
    //context.Set<Student>().Add(yaron);
    //context.Set<Student>().Add(shlomi);
    //context.Set<Student>().Add(marom);
    //context.Set<Student>().Add(Menahem);
    //context.Set<Student>().Add(Meshulam);
    //context.Set<Student>().Add(Benny);
    //context.Set<Student>().Add(Munitz);
    //context.Set<Student>().Add(messi);
    //context.Set<Student>().Add(hameleh);
    //context.Set<Student>().Add(NoProjStudent);
    //var Erez = new Lecturer(4, UserType.lecturer, "Erez", "Eres", "1", "sagifishman1@gmail.com",true);
    //var David = new Lecturer(15, UserType.lecturer, "David", "David", "1", "default@gmaol.com");
    //var Ohad = new Lecturer(5, UserType.lecturer, "Ohad", "Hahaham", "1", "default@gmaol.com");
    //var Meni = new Lecturer(6, UserType.lecturer, "Meni", "Shit", "1", "default@gmaol.com");
    //var Yossi = new Lecturer(2323, UserType.lecturer, "Yossi", "Eres", "1", "sagifishman1@gmail.com", true);
    //var Maroma = new Lecturer(4343, UserType.lecturer, "Maroma", "David", "1", "default@gmaol.com");
    //var Yosiad = new Lecturer(5656, UserType.lecturer, "Yosiad", "Hahaham", "1", "default@gmaol.com");
    //var Dorimon = new Lecturer(7878, UserType.lecturer, "Dorimon", "Shit", "1", "default@gmaol.com");
    //var Zeev = new Lecturer(998, UserType.lecturer, "Zeev", "Volkovic", "1", "sagifishman1@gmail.com", true);
    //var Dan = new Lecturer(1353, UserType.lecturer, "Dan", "Lamberg", "1", "default@gmaol.com");
    //var Elena = new Lecturer(23557, UserType.lecturer, "Elena", "Rave", "1", "default@gmaol.com");
    //var Elena2 = new Lecturer(34556, UserType.lecturer, "Elena", "Kremer", "1", "default@gmaol.com");
    //var Sarai = new Lecturer(25769, UserType.lecturer, "Sarai", "ADAa", "1", "sagifishman1@gmail.com", true);
    //var Anat = new Lecturer(4342343, UserType.lecturer, "Anat", "Dahan", "1", "default@gmaol.com");
    //var Dvora = new Lecturer(5648556, UserType.lecturer, "Dvora", "Toledano", "1", "default@gmaol.com");
    //var Zcharia = new Lecturer(7844678, UserType.lecturer, "Zcharia", "Frenkel", "1", "default@gmaol.com");
    //var David3 = new Lecturer(1533, UserType.lecturer, "AB", "CD", "1", "default@gmaol.com");
    //var Ohad3 = new Lecturer(533, UserType.lecturer, "YY", "ZZ", "1", "default@gmaol.com");
    //var Meni3 = new Lecturer(633, UserType.lecturer, "KK", "OO", "1", "default@gmaol.com");
    //var Yossi3 = new Lecturer(232333, UserType.lecturer, "UU", "II", "1", "sagifishman1@gmail.com", true);
    //var Maroma3 = new Lecturer(434333, UserType.lecturer, "EE", "TT", "1", "default@gmaol.com");
    //var Yosiad3 = new Lecturer(565633, UserType.lecturer, "BB", "CC", "1", "default@gmaol.com");
    //var Dorimon3 = new Lecturer(787833, UserType.lecturer, "ZZ", "XX", "1", "default@gmaol.com");
    //var Zeev3 = new Lecturer(99833, UserType.lecturer, "KK", "LL", "1", "sagifishman1@gmail.com", true);
    //var Dan3 = new Lecturer(135333, UserType.lecturer, "123", "321", "1", "default@gmaol.com");
    //var Elena3 = new Lecturer(2355733, UserType.lecturer, "456", "654", "1", "default@gmaol.com");
    //var Elena23 = new Lecturer(3455633, UserType.lecturer, "777", "888", "1", "default@gmaol.com");
    //var Sarai3 = new Lecturer(2576933, UserType.lecturer, "999", "000", "1", "sagifishman1@gmail.com", true);
    //var Anat3 = new Lecturer(434234333, UserType.lecturer, "333", "444", "1", "default@gmaol.com");
    //var Dvora3 = new Lecturer(564855633, UserType.lecturer, "123123", "123123", "1", "default@gmaol.com");
    //var Zcharia3 = new Lecturer(784467833, UserType.lecturer, "654", "888", "1", "default@gmaol.com");

    for (int i = 0; i < 30; i++)
    {
        var tempLec = new Lecturer(i, UserType.lecturer, "Firstname " + i, "Lastname " + i, "1", "default@gmail.com");
        var tempCon = new Random().Next(21);
        tempLec.constraints.Add(new LecConstraint(tempCon));
        tempLec.constraints.Add(new LecConstraint(tempCon + 5));
        tempLec.constraints.Add(new LecConstraint(tempCon + 10));
        tempLec.constraints.Add(new LecConstraint(tempCon + 15));
        context.Set<Lecturer>().Add(tempLec);
    }

    //context.Set<Lecturer>().Add(David3);
    //context.Set<Lecturer>().Add(Ohad3);
    //context.Set<Lecturer>().Add(Meni3);
    //context.Set<Lecturer>().Add(Yossi3);
    //context.Set<Lecturer>().Add(Maroma3);
    //context.Set<Lecturer>().Add(Yosiad3);
    //context.Set<Lecturer>().Add(Dorimon3);
    //context.Set<Lecturer>().Add(Dan3);
    //context.Set<Lecturer>().Add(Elena3);
    //context.Set<Lecturer>().Add(Elena23);
    //context.Set<Lecturer>().Add(Sarai3);
    //context.Set<Lecturer>().Add(Anat3);
    //context.Set<Lecturer>().Add(Dvora3);
    //context.Set<Lecturer>().Add(Zcharia3);
    //context.Set<Lecturer>().Add(Erez);
    //context.Set<Lecturer>().Add(Ohad);
    //context.Set<Lecturer>().Add(Meni);
    //context.Set<Lecturer>().Add(David);
    //context.Set<Lecturer>().Add(Yossi);
    //context.Set<Lecturer>().Add(Maroma);
    //context.Set<Lecturer>().Add(Yosiad);
    //context.Set<Lecturer>().Add(Dorimon);
    //context.Set<Lecturer>().Add(Zeev);
    //context.Set<Lecturer>().Add(Dan);
    //context.Set<Lecturer>().Add(Elena);
    //context.Set<Lecturer>().Add(Elena2);
    //context.Set<Lecturer>().Add(Sarai);
    //context.Set<Lecturer>().Add(Anat);
    //context.Set<Lecturer>().Add(Dvora);
    //context.Set<Lecturer>().Add(Zcharia);
    var Naomi = new Admin(7, UserType.admin, "Naomi", "Onklus", "1", "sagifishman1@gmail.com");
    context.Set<Admin>().Add(Naomi);
    
    //Project project1= new Project("Project Management", Erez.id, Sagi.id, Aviv.id, ProjectType.Research,"A");
    //context.Set<Project>().Add(project1);
    //Project project2 = new Project("Test Schedule", Erez.id, Natasha.id, yaron.id, ProjectType.Research, "A");
    //context.Set<Project>().Add(project2);
    //Project project3 = new Project("Image Painting", Ohad.id, yaron.id, lital.id, ProjectType.Development, "A");
    //context.Set<Project>().Add(project3);
    //Project project4 = new Project("akol tov", Meni.id, david.id, itay.id, ProjectType.Research, "A");
    //context.Set<Project>().Add(project4);
    //Project project5 = new Project("Aviv gayBaPe", Meni.id, Menahem.id, Meshulam.id, ProjectType.Development, "A");
    //context.Set<Project>().Add(project5);
    //Project project6 = new Project("Sagi Gever", Meni.id, marom.id, shlomi.id, ProjectType.Research, "A");
    //context.Set<Project>().Add(project6);
    //Project project7 = new Project("Project Name", Ohad.id, Benny.id, Munitz.id, ProjectType.Development, "A");
    //context.Set<Project>().Add(project7);
    //Project project8 = new Project("Name Of Project", Ohad.id, messi.id, hameleh.id, ProjectType.Development, "A");
    //context.Set<Project>().Add(project8);
    //Project project9 = new Project("Name Of Project", Ohad.id, messi.id, hameleh.id, ProjectType.Development, "A");
    //context.Set<Project>().Add(project9);
    context.SaveChanges();
    var lecturers = context.Set<Lecturer>().ToList();
    var students = context.Set<Student>().ToList();
    var tempListOfStudents = students;
    for (int i = 0; i < 60; i++)
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
    context.Set<Premission>().Add(new Premission(5, "Ohad AbuGay"));
    context.Set<Premission>().Add(new Premission(6, "Meni Mamtera"));



    ProjectProposal projectProposal = new ProjectProposal("Name", ProjectType.Development, "Development because .....", "keyword", "general description",
        "main tools", "planned Working Process During The First Semester", "product of the work", 2, 3, false, 4);
    context.Set<ProjectProposal>().Add(projectProposal);

    //LecturerPermissionToGiveGrades temp = new LecturerPermissionToGiveGrades(4,new List<>)
    //var lecturerConstraints = new LecturerConstraints();
    //lecturerConstraints.LecturerId = Erez.id;
    //var sessionList1 = new List<int>();
    //sessionList1.Add(1);
    //sessionList1.Add(3);
    //lecturerConstraints.Date1Constraint = new LecturerConstraint(DateTime.Today, sessionList1);
    //var sessionList2 = new List<int>();
    //sessionList2.Add(2);
    //sessionList2.Add(4);
    //lecturerConstraints.Date2Constraint = new LecturerConstraint(DateTime.Today, sessionList2);
    //context.Set<LecturerConstraints>().Add(lecturerConstraints);
    context.SaveChanges();
}