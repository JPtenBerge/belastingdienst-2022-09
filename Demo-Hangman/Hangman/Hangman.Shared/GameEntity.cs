using System.ComponentModel.DataAnnotations;

namespace Hangman.Shared;

public class GameEntity
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string WordToGuess { get; set; }

    public int NrOfIncorrectGuesses { get; set; }

    [MaxLength(30)]
    public string GuessedLetters { get; set; }

    public GameState State { get; set; }

    public int PlayerId { get; set; }
    
    public PlayerEntity Player { get; set; }
}