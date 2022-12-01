using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PubContext : DbContext
{
    //public DbSet<User> Users { get; set; } = null!;
    //public DbSet<UserType> UserTypes { get; set; } = null!;

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
    }
}