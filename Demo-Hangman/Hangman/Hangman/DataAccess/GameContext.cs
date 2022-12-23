using Hangman.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hangman;

public class GameContext : DbContext
{
    public DbSet<GameEntity> Games { get; set; }

    public DbSet<PlayerEntity> Players { get; set; }

    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {
        
    }
}