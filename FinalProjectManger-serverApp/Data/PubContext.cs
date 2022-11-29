using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class PubContext : DbContext
{
    public DbSet<User> Users { get; set;  }
    public DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDb; Initial Catalog = PubDataBase");
    }

}