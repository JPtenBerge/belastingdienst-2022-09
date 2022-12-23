using Hangman.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameContext _context;
    public GameRepository(GameContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<GameEntity>> GetAllAsync()
    {
        return await _context.Games.ToArrayAsync();
    }
    
    public async Task<GameEntity> GetAsync(int gameId)
    {
        return await _context.Games.SingleAsync(x => x.Id == gameId);
    }

    public async Task<GameEntity> StartNewAsync(GameEntity game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return game;
    }

    public async Task<GameEntity> UpdateAsync(GameEntity game)
    {
        var gameEntity = await GetAsync(game.Id);
        gameEntity.GuessedLetters = game.GuessedLetters;
        gameEntity.NrOfIncorrectGuesses = game.NrOfIncorrectGuesses;
        gameEntity.State = game.State;

        await _context.SaveChangesAsync();
        return game;
    }
}