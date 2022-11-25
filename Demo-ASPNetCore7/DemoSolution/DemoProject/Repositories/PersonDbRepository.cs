using System.Linq.Expressions;
using DemoProject.DataAccess;
using DemoProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories;

public class PersonDbRepository : IPersonRepository
{
    private PeopleContext _context;
    public PersonDbRepository(PeopleContext context)
    {
        _context = context;
    }

    // alle coole mensen:
    // - aparte methode
    // - GetAllAsync().Where(). mooi qua hergebruik. alleen nog maar ff filteren. liefst database dit werk laten doen.
    // - parameters
    //   - GetAllAsync(boolean alleenCool)
    //   - GetAllAsync(boolean alleenCool, boolean alleenNietCool)
    //   - GetAllAsync(int minAge)
    //   - GetAllAsync(int maxAge)
    // - Func<> parameters
    //   - GetAllAsync(Expression<Func<>, FUnc<> order, Func<> group, take, skip)
    // - IQueryable<> teruggeven? Aanroepende partij moet dan Microsoft.EntityFrameworkCore usen voor de .ToListAsync()
    
    public async Task<IEnumerable<PersonEntity>> GetAllAsync() // deferred execution
    {
        // ToListAsync forceert een query richting de database
        return await _context.Persons.Include(x => x.Profession).ToListAsync(); // dit haalt de data nog niet daadwerkelijk uit je database
    }

    public async Task<PersonEntity> AddAsync(PersonEntity newPerson)
    {
        _context.Persons.Add(newPerson); // dit doet nog geen query uitvoeren
        await _context.SaveChangesAsync(); // deze wel
        return newPerson; // updated entity
    }
}