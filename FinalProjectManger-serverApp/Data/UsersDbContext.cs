using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserType> UserTypes { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDb; Initial Catalog = PubDataBase");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        //modelBuilder.Entity<UserType>()
        //    .Property(e => e.Id).ValueGeneratedNever();

        modelBuilder.Entity<User>()
            .Property(e => e.Id).ValueGeneratedNever();
        modelBuilder.Entity<User>().OwnsOne(x => x.Type);

        modelBuilder.Entity<Project>()
            .Property(e => e.ProjectId).ValueGeneratedNever();
        modelBuilder.Entity<Project>()
            .OwnsOne(e => e.student1)
            .OwnsOne(e=>e.Type);
        //modelBuilder.Entity<GradeA>()
        //    .Property(e => e.gradeA_ID).ValueGeneratedNever();
        //modelBuilder.Entity<GradeA>().OwnsOne(x => x.bookGrade);
        //modelBuilder.Entity<GradeA>().OwnsOne(x => x.presentationGrade);
        //modelBuilder.Entity<GradeA>().OwnsOne(x => x.lecturerGrade);

        //modelBuilder.Entity<GradeB>()
        //  .Property(e => e.gradeB_ID).ValueGeneratedNever();
        //modelBuilder.Entity<GradeB>().OwnsOne(x => x.bookGrade);
        //modelBuilder.Entity<GradeB>().OwnsOne(x => x.presentationGrade);
        //modelBuilder.Entity<GradeB>().OwnsOne(x => x.lecturerGrade);
    }
}