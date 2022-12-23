using Hangman.Shared;

namespace Hangman.Repositories;

public interface IPlayerRepository
{
    Task<IEnumerable<PlayerEntity>> GetAllAsync();
    Task<PlayerEntity> GetOrCreate(string name);
}