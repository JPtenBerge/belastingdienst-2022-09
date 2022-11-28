using Demo.Shared.Entities;

namespace DemoProject.Repositories;

public class PersonInMemoryRepository : IPersonRepository
{
    // services
    // inversion of control
    // => dependency injection
    
    private static List<PersonEntity> Persons { get; set; } = new()
    {
        new()
        {
            Id = 4,
            Name = "Elon Musk",
            Age = 51
        },
        new()
        {
            Id = 8,
            Name = "Jeffrey Bezos",
            Age = 58
        },
        new()
        {
            Id = 15,
            Name = "Billy Gates",
            Age = 67
        }
    };

    public Task<IEnumerable<PersonEntity>> GetAllAsync()
    {
        return Task.FromResult(Persons.AsEnumerable());
    }

    public Task<PersonEntity> AddAsync(PersonEntity newPerson)
    {
        newPerson.Id = Persons.Max(x => x.Id) + 1;
        Persons.Add(newPerson);
        return Task.FromResult(newPerson); // updated entity
    }
}