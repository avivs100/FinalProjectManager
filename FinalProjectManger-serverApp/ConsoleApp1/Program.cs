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
    var Natasha = new Student(1, UserType.student, "Natasha", "ABC", "1","sagifishman1@gmail.com");
    var Sagi = new Student(2, UserType.student, "Sagi", "Fishman", "1", "sagifishman1@gmail.com");
    var Aviv = new Student(3, UserType.student, "Aviv", "GayBa", "1", "avivshichman@gmail.com" );
    var itay = new Student(11, UserType.student, "Itay", "ABC", "1", "FinalProjectManager@outlook.com");
    var lital = new Student(8, UserType.student, "Lital", "Fishman", "1", "default@gmail.com");
    var yaron = new Student(9, UserType.student, "Yaron", "Cohen", "1", "default@gmail.com");
    var david = new Student(10, UserType.student, "David", "Levi", "1", "default@gmail.com");
    var shlomi = new Student(1114, UserType.student, "shlomi", "Ashkenazi", "1", "default@gmail.com");
    var marom = new Student(12, UserType.student, "marom", "Muhamad", "1", "default@gmail.com");
    var Menahem = new Student(13, UserType.student, "Yaron", "Argaz", "1", "default@gmail.com");
    var Meshulam = new Student(14, UserType.student, "David", "Kesef", "1", "default@gmail.com");
    var Benny = new Student(15, UserType.student, "Benny", "Kise", "1", "default@gmail.com");
    var Munitz = new Student(16, UserType.student, "Munitz", "Shulhan", "1", "default@gmail.com");
    var messi = new Student(17, UserType.student, "Messi", "Kise", "1", "default@gmail.com");
    var hameleh = new Student(18, UserType.student, "King", "Shulhan", "1", "default@gmail.com");
    var NoProjStudent = new Student(20, UserType.student, "Name Of No Proj", "Shulhan", "1", "default@gmail.com");
    context.Set<Student>().Add(Natasha);
    context.Set<Student>().Add(Sagi);
    context.Set<Student>().Add(Aviv);
    context.Set<Student>().Add(itay);
    context.Set<Student>().Add(lital);
    context.Set<Student>().Add(david);
    context.Set<Student>().Add(yaron);
    context.Set<Student>().Add(shlomi);
    context.Set<Student>().Add(marom);
    context.Set<Student>().Add(Menahem);
    context.Set<Student>().Add(Meshulam);
    context.Set<Student>().Add(Benny);
    context.Set<Student>().Add(Munitz);
    context.Set<Student>().Add(messi);
    context.Set<Student>().Add(hameleh);
    context.Set<Student>().Add(NoProjStudent);
    var Erez = new Lecturer(4, UserType.lecturer, "Erez", "Eres", "1", "sagifishman1@gmail.com",true);
    var David = new Lecturer(15, UserType.lecturer, "David", "David", "1", "default@gmaol.com");
    var Ohad = new Lecturer(5, UserType.lecturer, "Ohad", "Hahaham", "1", "default@gmaol.com");
    var Meni = new Lecturer(6, UserType.lecturer, "Meni", "Shit", "1", "default@gmaol.com");
    var Yossi = new Lecturer(2323, UserType.lecturer, "Yossi", "Eres", "1", "sagifishman1@gmail.com", true);
    var Maroma = new Lecturer(4343, UserType.lecturer, "Maroma", "David", "1", "default@gmaol.com");
    var Yosiad = new Lecturer(5656, UserType.lecturer, "Yosiad", "Hahaham", "1", "default@gmaol.com");
    var Dorimon = new Lecturer(7878, UserType.lecturer, "Dorimon", "Shit", "1", "default@gmaol.com");
    var Zeev = new Lecturer(998, UserType.lecturer, "Zeev", "Volkovic", "1", "sagifishman1@gmail.com", true);
    var Dan = new Lecturer(1353, UserType.lecturer, "Dan", "Lamberg", "1", "default@gmaol.com");
    var Elena = new Lecturer(23557, UserType.lecturer, "Elena", "Rave", "1", "default@gmaol.com");
    var Elena2 = new Lecturer(34556, UserType.lecturer, "Elena", "Kremer", "1", "default@gmaol.com");
    var Sarai = new Lecturer(25769, UserType.lecturer, "Sarai", "ADAa", "1", "sagifishman1@gmail.com", true);
    var Anat = new Lecturer(4342343, UserType.lecturer, "Anat", "Dahan", "1", "default@gmaol.com");
    var Dvora = new Lecturer(5648556, UserType.lecturer, "Dvora", "Toledano", "1", "default@gmaol.com");
    var Zcharia = new Lecturer(7844678, UserType.lecturer, "Zcharia", "Frenkel", "1", "default@gmaol.com");
    var David3 = new Lecturer(1533, UserType.lecturer, "AB", "CD", "1", "default@gmaol.com");
    var Ohad3 = new Lecturer(533, UserType.lecturer, "YY", "ZZ", "1", "default@gmaol.com");
    var Meni3 = new Lecturer(633, UserType.lecturer, "KK", "OO", "1", "default@gmaol.com");
    var Yossi3 = new Lecturer(232333, UserType.lecturer, "UU", "II", "1", "sagifishman1@gmail.com", true);
    var Maroma3 = new Lecturer(434333, UserType.lecturer, "EE", "TT", "1", "default@gmaol.com");
    var Yosiad3 = new Lecturer(565633, UserType.lecturer, "BB", "CC", "1", "default@gmaol.com");
    var Dorimon3 = new Lecturer(787833, UserType.lecturer, "ZZ", "XX", "1", "default@gmaol.com");
    var Zeev3 = new Lecturer(99833, UserType.lecturer, "KK", "LL", "1", "sagifishman1@gmail.com", true);
    var Dan3 = new Lecturer(135333, UserType.lecturer, "123", "321", "1", "default@gmaol.com");
    var Elena3 = new Lecturer(2355733, UserType.lecturer, "456", "654", "1", "default@gmaol.com");
    var Elena23 = new Lecturer(3455633, UserType.lecturer, "777", "888", "1", "default@gmaol.com");
    var Sarai3 = new Lecturer(2576933, UserType.lecturer, "999", "000", "1", "sagifishman1@gmail.com", true);
    var Anat3 = new Lecturer(434234333, UserType.lecturer, "333", "444", "1", "default@gmaol.com");
    var Dvora3 = new Lecturer(564855633, UserType.lecturer, "123123", "123123", "1", "default@gmaol.com");
    var Zcharia3 = new Lecturer(784467833, UserType.lecturer, "654", "888", "1", "default@gmaol.com");
    context.Set<Lecturer>().Add(David3);
    context.Set<Lecturer>().Add(Ohad3);
    context.Set<Lecturer>().Add(Meni3);
    context.Set<Lecturer>().Add(Yossi3);
    context.Set<Lecturer>().Add(Maroma3);
    context.Set<Lecturer>().Add(Yosiad3);
    context.Set<Lecturer>().Add(Dorimon3);
    context.Set<Lecturer>().Add(Dan3);
    context.Set<Lecturer>().Add(Elena3);
    context.Set<Lecturer>().Add(Elena23);
    context.Set<Lecturer>().Add(Sarai3);
    context.Set<Lecturer>().Add(Anat3);
    context.Set<Lecturer>().Add(Dvora3);
    context.Set<Lecturer>().Add(Zcharia3);
    context.Set<Lecturer>().Add(Erez);
    context.Set<Lecturer>().Add(Ohad);
    context.Set<Lecturer>().Add(Meni);
    context.Set<Lecturer>().Add(David);
    context.Set<Lecturer>().Add(Yossi);
    context.Set<Lecturer>().Add(Maroma);
    context.Set<Lecturer>().Add(Yosiad);
    context.Set<Lecturer>().Add(Dorimon);
    context.Set<Lecturer>().Add(Zeev);
    context.Set<Lecturer>().Add(Dan);
    context.Set<Lecturer>().Add(Elena);
    context.Set<Lecturer>().Add(Elena2);
    context.Set<Lecturer>().Add(Sarai);
    context.Set<Lecturer>().Add(Anat);
    context.Set<Lecturer>().Add(Dvora);
    context.Set<Lecturer>().Add(Zcharia);
    var Naomi = new Admin(7, UserType.admin, "Naomi", "Onklus", "1", "sagifishman1@gmail.com");
    context.Set<Admin>().Add(Naomi);

    Grade organization1 = new Grade("Almost", 80, 0.25, "organization");
    Grade qualityOfProblem1 = new Grade("Not Good", 60, 0.25, "Quality Of Problem");
    Grade technicalQuality1 = new Grade("Wow", 100, 0.25, "Technical Quality");
    Grade generalEvaluation1 = new Grade("Very Good", 90, 0.25, "General Evaluation");
    string additionalComment1 = "Imale Ve Abale";
    var PresentationGrade1 = new PresentationGrade(organization1, qualityOfProblem1, technicalQuality1,
        generalEvaluation1, additionalComment1);
    Grade organization2 = new Grade("Good", 90, 0.25, "organization");
    Grade qualityOfProblem2 = new Grade("Plus Minus", 80, 0.25, "Quality Of Problem");
    Grade technicalQuality2 = new Grade("Minus Plus", 80, 0.25, "Technical Quality");
    Grade generalEvaluation2 = new Grade("Very Good", 90, 0.25, "General Evaluation");
    string additionalComment2 = "Additional comment is wowwwww";
    var PresentationGrade2 = new PresentationGrade(organization2, qualityOfProblem2, technicalQuality2,
        generalEvaluation2, additionalComment2);
    Grade organization3 = new Grade("Hi", 70, 0.25, "organization");
    Grade qualityOfProblem3 = new Grade("Hipasti kvar", 85, 0.25, "Quality Of Problem");
    Grade technicalQuality3 = new Grade("Be Kol", 77, 0.25, "Technical Quality");
    Grade generalEvaluation3 = new Grade("Midbar", 91, 0.25, "General Evaluation");
    string additionalComment3 = "Yasmin Mualem";
    var PresentationGrade3 = new PresentationGrade(organization3, qualityOfProblem3, technicalQuality3,
        generalEvaluation3, additionalComment3);
    context.Set<PresentationGrade>().Add(PresentationGrade1);
    context.Set<PresentationGrade>().Add(PresentationGrade2);
    context.Set<PresentationGrade>().Add(PresentationGrade3);
    Grade grade1 = new Grade("Hello", 70, 0.5, "organization");
    Grade grade2 = new Grade("Haviv", 85, 0.5, "Quality Of Problem");
    LecturerGrade lecturerGrade1 = new LecturerGrade(grade1, grade2, "Description is imale ve abale");
    Grade grade3 = new Grade("Erez Lo Mafsik", 65, 0.5, "organization");
    Grade grade4 = new Grade("Lihiot gayba", 98, 0.5, "Quality Of Problem");
    LecturerGrade lecturerGrade2 = new LecturerGrade(grade3, grade4, "Aviv Kibel Mahshev Al Hapanim");
    context.Set<LecturerGrade>().Add(lecturerGrade1);
    context.Set<LecturerGrade>().Add(lecturerGrade2);

    Grade research1 = new Grade("ABACA ", 96, 0.16, "research");
    Grade analysisAndConclusion1 = new Grade("YOYOYOYO", 77, 0.16, "analysisAndConclusion");
    Grade swQuality1 = new Grade("YAYAYAYA", 68, 0.16, "swQuality ");
    Grade uIandAPPguides1 = new Grade("LOLOLOLOLO", 93, 0.16, "uIandAPPguides");
    Grade organization11 = new Grade("NININININI", 87, 0.16, "organization");
    Grade generalEvaluation11 = new Grade("SHEMO", 89, 0.16, "generalEvaluation");
    Grade research2 = new Grade("OSJAFSFS ", 100, 0.16, "research");
    Grade analysisAndConclusion2 = new Grade("RPREPGD", 89, 0.16, "analysisAndConclusion");
    Grade swQuality2 = new Grade("ASFSDNKGS", 77, 0.16, "swQuality ");
    Grade uIandAPPguides2 = new Grade("SDGDGFDHB", 93, 0.16, "uIandAPPguides");
    Grade organization12 = new Grade("sdfgDFGDFG", 86, 0.16, "organization");
    Grade generalEvaluation12 = new Grade("sdGafdhnft", 45, 0.16, "generalEvaluation");

    BookGrade bookGrade1 = new BookGrade(research1, analysisAndConclusion1, swQuality1, uIandAPPguides1, organization11, generalEvaluation11);
    BookGrade bookGrade2 = new BookGrade(research2, analysisAndConclusion2, swQuality2, uIandAPPguides2, organization12, generalEvaluation12);
    context.Set<BookGrade>().Add(bookGrade1);
    context.Set<BookGrade>().Add(bookGrade2);

    GradeA gradeA1 = new GradeA(PresentationGrade1,bookGrade1,lecturerGrade1);
    GradeA gradeA2 = new GradeA(PresentationGrade2, bookGrade2, lecturerGrade2);
    context.Set<GradeA>().Add(gradeA1);
    context.Set<GradeA>().Add(gradeA2);
    GradeB gradeB1 = new GradeB(PresentationGrade1, bookGrade1, lecturerGrade1);
    GradeB gradeB2 = new GradeB(PresentationGrade2, bookGrade2, lecturerGrade2);
    context.Set<GradeB>().Add(gradeB1);
    context.Set<GradeB>().Add(gradeB2);
    
    Project project1= new Project("Project Management", Erez.id, Sagi.id, Aviv.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Research,"A");
    context.Set<Project>().Add(project1);
    Project project2 = new Project("Test Schedule", Erez.id, Natasha.id, yaron.id, gradeA2.gradeAid, gradeB2.gradeBid, ProjectType.Research, "A");
    context.Set<Project>().Add(project2);
    Project project3 = new Project("Image Painting", Ohad.id, yaron.id, lital.id, gradeA2.gradeAid, gradeB2.gradeBid, ProjectType.Development, "A");
    context.Set<Project>().Add(project3);
    Project project4 = new Project("akol tov", Meni.id, david.id, itay.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Research, "A");
    context.Set<Project>().Add(project4);
    Project project5 = new Project("Aviv gayBaPe", Meni.id, Menahem.id, Meshulam.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Development, "A");
    context.Set<Project>().Add(project5);
    Project project6 = new Project("Sagi Gever", Meni.id, marom.id, shlomi.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Research, "A");
    context.Set<Project>().Add(project6);
    Project project7 = new Project("Project Name", Ohad.id, Benny.id, Munitz.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Development, "A");
    context.Set<Project>().Add(project7);
    Project project8 = new Project("Name Of Project", Ohad.id, messi.id, hameleh.id, gradeA1.gradeAid, gradeB1.gradeBid, ProjectType.Development, "A");
    context.Set<Project>().Add(project8);
    context.Set<Premission>().Add(new Premission(5, "Ohad AbuGay"));
    context.Set<Premission>().Add(new Premission(6, "Meni Mamtera"));
    var projList = new List<Project>();
    projList.Add(project1);
    projList.Add(project2);
    projList.Add(project3);
    projList.Add(project4);
    projList.Add(project5);
    projList.Add(project6);
    //Session session1 = new Session(Erez.id, Meni.id, Ohad.id, projList, 1);
    //Session session2 = new Session(Benny.id, David.id, Ohad.id, projList, 2);
    //context.Set<Session>().Add(session1);
    //context.Set<Session>().Add(session2);
    //DayInSchedule dayInSchedule1= new DayInSchedule(true, session1.Id, session2.Id, session1.Id, session2.Id, session1.Id);
    //DayInSchedule dayInSchedule2 = new DayInSchedule(false, session1.Id, session2.Id, session1.Id, session2.Id, session1.Id);
    //context.Set<DayInSchedule>().Add(dayInSchedule1);
    //context.Set<DayInSchedule>().Add(dayInSchedule2);

    //Schedule schedule = new Schedule(dayInSchedule1.Id, dayInSchedule2.Id);
    //context.Set<Schedule>().Add(schedule);

    ProjectProposal projectProposal = new ProjectProposal("Name", ProjectType.Development, "Development because .....", "keyword", "general description",
        "main tools", "planned Working Process During The First Semester", "product of the work", 2, 3, false, 4);
    context.Set<ProjectProposal>().Add(projectProposal);
    var preList = new List<int>();
    preList.Add(PresentationGrade1.Id);
    preList.Add(PresentationGrade2.Id);
    var bookList = new List<int>();
    bookList.Add(bookGrade1.Id);
    bookList.Add(bookGrade2.Id);
    var lecList = new List<int>();
    lecList.Add(lecturerGrade1.Id);
    lecList.Add(lecturerGrade2.Id);
    var lecturerPermissionToGiveGrades = new LecturerPermissionToGiveGrades(Erez.id, preList, bookList, lecList);
    context.Set<LecturerPermissionToGiveGrades>().Add(lecturerPermissionToGiveGrades);
    //LecturerPermissionToGiveGrades temp = new LecturerPermissionToGiveGrades(4,new List<>)
    var lecturerConstraints = new LecturerConstraints();
    lecturerConstraints.LecturerId = Erez.id;
    var sessionList1 = new List<int>();
    sessionList1.Add(1);
    sessionList1.Add(3);
    lecturerConstraints.Date1Constraint = new LecturerConstraint(DateTime.Today, sessionList1);
    var sessionList2 = new List<int>();
    sessionList2.Add(2);
    sessionList2.Add(4);
    lecturerConstraints.Date2Constraint = new LecturerConstraint(DateTime.Today, sessionList2);
    context.Set<LecturerConstraints>().Add(lecturerConstraints);
    context.SaveChanges();
}