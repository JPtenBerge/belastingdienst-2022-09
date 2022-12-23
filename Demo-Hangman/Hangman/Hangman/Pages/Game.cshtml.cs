using Hangman.Repositories;
using Hangman.Services;
using Hangman.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hangman.Pages;

public class Game : PageModel
{
    public char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    private static int MaxNrOfGuesses = 5;
    public string? NotificationMessage { get; set; }
    
    public GameEntity CurrentGame { get; set; }
    private readonly IGameRepository _gameRepo;
    private readonly IGameService _gameService;
    
    public Game(IGameRepository gameRepo, IGameService gameService)
    {
        _gameRepo = gameRepo;
        _gameService = gameService;
    }
    
    public async Task OnGetAsync(int gameId, string? letter)
    {
        CurrentGame = await _gameRepo.GetAsync(gameId);

        if (letter != null)
        {
            await Guess(letter);
        }
    }

    private async Task Guess(string letter)
    {
        letter = letter.ToUpper();

        var (result, message) = _gameService.IsValidGuess(CurrentGame, letter);
        if (!result)
        {
            NotificationMessage = message; 
            return;
        }
        
        CurrentGame.GuessedLetters += letter;

        if (!CurrentGame.WordToGuess.Contains(letter))
        {
            CurrentGame.NrOfIncorrectGuesses++;
        }

        // has word been guessed? there must be something fancier for this
        if (_gameService.HasWordBeenGuessed(CurrentGame))
        {
            CurrentGame.State = GameState.Solved;
        }
        
        if (CurrentGame.NrOfIncorrectGuesses >= MaxNrOfGuesses)
        {
            CurrentGame.State = GameState.Unsolved;
        }
        
        await _gameRepo.UpdateAsync(CurrentGame);
    }
}