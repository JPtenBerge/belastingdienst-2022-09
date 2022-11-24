using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataAccess;

public class PeopleContext : DbContext
{
    public DbSet<PersonEntity> Persons { get; set; } // table

    public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
    {
        
    }
}