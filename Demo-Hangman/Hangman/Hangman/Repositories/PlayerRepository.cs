using Hangman.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hangman.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly GameContext _context;
    public PlayerRepository(GameContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<PlayerEntity>> GetAllAsync()
    {
        return await _context.Players.ToArrayAsync();
    }

    public async Task<PlayerEntity> GetOrCreate(string name)
    {
        var player = await _context.Players.SingleOrDefaultAsync(x => x.Name == name);
        if (player == null)
        {
            player = new PlayerEntity()
            {
                Name = name
            };    
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
        return player;
    }
}