using Hangman.Repositories;
using Hangman.Services;
using Hangman.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman.Pages;

public class NewGameModel : PageModel
{
    private readonly IGameRepository _gameRepo;
    private readonly IPlayerRepository _playerRepo;
    private readonly IWordService _wordService;
    [BindProperty] public string PlayerName { get; set; }
    
    public NewGameModel(IGameRepository gameRepo, IPlayerRepository playerRepo, IWordService wordService)
    {
        _gameRepo = gameRepo;
        _playerRepo = playerRepo;
        _wordService = wordService;
    }
    
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var player = await _playerRepo.GetOrCreate(PlayerName);
        var game = new GameEntity
        {
            WordToGuess = _wordService.GetRandomWord(),
            GuessedLetters = string.Empty,
            State = GameState.InProgress,
            PlayerId = player.Id
        };
        var newGame = await _gameRepo.StartNewAsync(game);
        return Redirect($"/game/{newGame.Id}");
    }
}