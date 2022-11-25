using DemoProject.Entities;

namespace DemoProject.Repositories;

public interface IProfessionRepository
{
    Task<IEnumerable<ProfessionEntity>> GetAll();
}