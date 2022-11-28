using Demo.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.DataAccess;

public class PeopleContext : IdentityDbContext<ScratchUser>
{
    public DbSet<PersonEntity> Persons { get; set; } // table

    public DbSet<ProfessionEntity> Professions { get; set; }

    public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
    {
        
    }
}