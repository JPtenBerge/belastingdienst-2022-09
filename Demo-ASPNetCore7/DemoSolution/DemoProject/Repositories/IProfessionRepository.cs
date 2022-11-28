using Demo.Shared.Entities;

namespace DemoProject.Repositories;

public interface IProfessionRepository
{
    Task<IEnumerable<ProfessionEntity>> GetAllAsync();
}