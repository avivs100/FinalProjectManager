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
    var Natasha = new Student(1, UserType.student, "Natasha", "ABC", "1");
    var Sagi = new Student(2, UserType.student, "Sagi", "Fishman", "1");
    var Aviv = new Student(3, UserType.student, "Aviv", "GayBa", "1");
    var itay = new Student(11, UserType.student, "Itay", "ABC", "1");
    var lital = new Student(8, UserType.student, "Lital", "Fishman", "1");
    var yaron = new Student(9, UserType.student, "Yaron", "GayBa", "1");
    var david = new Student(10, UserType.student, "David", "GayBa", "1");
    context.Set<Student>().Add(Natasha);
    context.Set<Student>().Add(Sagi);
    context.Set<Student>().Add(Aviv);
    var Erez = new Lecturer(4, UserType.lecturer, "Erez", "Eres", "1");
    var con1 = new Constraint(2022, 12, 9, 13, 22, 45);
    context.Set<Constraint>().Add(con1);
    Erez.constraints.Add(con1);
    var con = new Constraint(2022, 12, 9, 16, 15, 33);
    Erez.constraints.Add(con);
    context.Set<Constraint>().Add(con);
    var Ohad = new Lecturer(5, UserType.lecturer, "Ohad", "Hahaham", "1");
    con = new Constraint(2022, 11, 4, 7, 55, 34);
    Ohad.constraints.Add(con);
    context.Set<Constraint>().Add(con);
    con = new Constraint(2022, 9, 2, 19, 15, 52);
    Ohad.constraints.Add(con);
    context.Set<Constraint>().Add(con);
    var Meni = new Lecturer(6, UserType.lecturer, "Meni", "Shit", "1");
    con = new Constraint(2022, 4, 2, 5, 31, 17);
    Meni.constraints.Add(con);
    context.Set<Constraint>().Add(con);
    context.Set<Lecturer>().Add(Erez);
    context.Set<Lecturer>().Add(Ohad);
    context.Set<Lecturer>().Add(Meni);

    var Naomi = new Admin(7, UserType.admin, "Naomi", "Onklus", "1");
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

    Project project1= new Project("Project Management", Erez.id, Sagi.id, Aviv.id, gradeA1.gradeAid, gradeB1.gradeBid);
    context.Set<Project>().Add(project1);

    Project project2 = new Project("akol tov", Erez.id, Natasha.id, yaron.id, gradeA2.gradeAid, gradeB2.gradeBid);
    context.Set<Project>().Add(project1);
    context.SaveChanges();
}