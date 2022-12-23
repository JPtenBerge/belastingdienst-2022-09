using Hangman.Shared;

namespace Hangman.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<GameEntity>> GetAllAsync();
    Task<GameEntity> GetAsync(int gameId);
    Task<GameEntity> StartNewAsync(GameEntity game);

    Task<GameEntity> UpdateAsync(GameEntity game);
}