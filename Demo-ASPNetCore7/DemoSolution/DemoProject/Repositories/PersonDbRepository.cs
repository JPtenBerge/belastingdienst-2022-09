using DemoProject.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class PersonDbRepository : IPersonRepository
{
    private PeopleContext _context;
    public PersonDbRepository(PeopleContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PersonEntity>> GetAllAsync() // deferred execution
    {
        // ToListAsync forceert een query richting de database
        return await _context.Persons.ToListAsync(); // dit haalt de data nog niet daadwerkelijk uit je database
    }

    public async Task<PersonEntity> AddAsync(PersonEntity newPerson)
    {
        _context.Persons.Add(newPerson); // dit doet nog geen query uitvoeren
        await _context.SaveChangesAsync(); // deze wel
        return newPerson; // updated entity
    }
}