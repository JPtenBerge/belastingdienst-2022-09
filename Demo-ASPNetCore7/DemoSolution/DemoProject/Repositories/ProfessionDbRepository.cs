using DemoProject.DataAccess;
using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class ProfessionDbRepository : IProfessionRepository
{
    private PeopleContext _context;
    public ProfessionDbRepository(PeopleContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProfessionEntity>> GetAll()
    {
        return await _context.Professions.ToListAsync();
    }
}