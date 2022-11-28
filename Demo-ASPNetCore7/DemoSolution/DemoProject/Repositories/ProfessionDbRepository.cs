using DemoProject.DataAccess;
using Demo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class ProfessionDbRepository : IProfessionRepository
{
    private PeopleContext _context;
    public ProfessionDbRepository(PeopleContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<ProfessionEntity>> GetAllAsync()
    {
        return await _context.Professions.ToListAsync();
    }
}