using Demo.Shared.Entities;

namespace DemoProject.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<PersonEntity>> GetAllAsync();
    Task<PersonEntity> AddAsync(PersonEntity newPerson);
}