using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Data;

public class UsersDbContext : DbContext
{
    //public DbSet<User> Users { get; set; } = null!;
    //public DbSet<UserType> UserTypes { get; set; } = null!;
    //public DbSet<Student> Students { get; set; } = null!;
    //public DbSet<Project> Projects { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDb; Initial Catalog = PubDataBase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().Property(e => e.id).ValueGeneratedNever();

        modelBuilder.Entity<LecConstraint>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<LecConstraint>().Property(e => e.SessionNumber).ValueGeneratedNever();

        modelBuilder.Entity<Lecturer>().Property(e => e.id).ValueGeneratedNever();


        modelBuilder.Entity<Admin>().Property(e => e.id).ValueGeneratedNever();

        modelBuilder.Entity<LecturerGrade>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<LecturerGrade>().OwnsOne(x => x.Grade1);
        modelBuilder.Entity<LecturerGrade>().OwnsOne(x => x.Grade2);

        modelBuilder.Entity<BookGrade>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.AnalysisAndConclusion);
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.UIandAPPguides);
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.Research);
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.Organization);
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.SwQuality);
        modelBuilder.Entity<BookGrade>().OwnsOne(x => x.GeneralEvaluation);

        modelBuilder.Entity<PresentationGrade>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<PresentationGrade>().OwnsOne(x => x.Organization);
        modelBuilder.Entity<PresentationGrade>().OwnsOne(x => x.QualityOfProblem);
        modelBuilder.Entity<PresentationGrade>().OwnsOne(x => x.TechnicalQuality);
        modelBuilder.Entity<PresentationGrade>().OwnsOne(x => x.GeneralEvaluation);

        modelBuilder.Entity<GradeA>().Property(e => e.gradeAid).ValueGeneratedNever();
        modelBuilder.Entity<GradeA>().HasOne(x => x.bookGrade);
        modelBuilder.Entity<GradeA>().HasOne(x => x.presentationGrade);
        modelBuilder.Entity<GradeA>().HasOne(x => x.lecturerGrade);

        modelBuilder.Entity<GradeB>().Property(e => e.gradeBid).ValueGeneratedNever();
        modelBuilder.Entity<GradeB>().HasOne(x => x.bookGrade);
        modelBuilder.Entity<GradeB>().HasOne(x => x.presentationGrade);
        modelBuilder.Entity<GradeB>().HasOne(x => x.lecturerGrade);

        modelBuilder.Entity<Project>().Property(e => e.ProjectId).ValueGeneratedNever();

        modelBuilder.Entity<ScheduleDates>().Property(e => e.id).ValueGeneratedNever();

        modelBuilder.Entity<Premission>().Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<Session>().Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<DayInSchedule>().Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<Schedule>().Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<ProjectProposal>().Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<LecturerPermissionToGiveGrades>().Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<LecturerPermissionToGiveGrades>().OwnsOne(e => e.BookGradeId);
        modelBuilder.Entity<LecturerPermissionToGiveGrades>().OwnsOne(e => e.LecturerGradeId);
        modelBuilder.Entity<LecturerPermissionToGiveGrades>().OwnsOne(e => e.PresentationGradeId);

        modelBuilder.Entity<LecturerConstraints>().HasKey(e => e.LecturerId);
        modelBuilder.Entity<LecturerConstraints>().Property(e => e.LecturerId).ValueGeneratedNever();
        modelBuilder.Entity<LecturerConstraints>().OwnsOne(e => e.Date1Constraint);
        modelBuilder.Entity<LecturerConstraints>().OwnsOne(e => e.Date2Constraint);



    }
}