using Hangman.Repositories;
using Hangman.Services;
using Hangman.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman.Pages;

public class GamesModel : PageModel
{
    public IEnumerable<GameEntity>? Games { get; set; }
    
    private readonly IGameRepository _gameRepo;
    public GamesModel(IGameRepository gameRepo)
    {
        _gameRepo = gameRepo;
    }
    public async Task OnGetAsync()
    {
        Games = await _gameRepo.GetAllAsync();
    }
}