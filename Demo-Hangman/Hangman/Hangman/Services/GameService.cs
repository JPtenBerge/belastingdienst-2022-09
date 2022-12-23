using Hangman.Shared;

namespace Hangman.Services;

public class GameService : IGameService
{
    public (bool, string?) IsValidGuess(GameEntity game, string letter)
    {
        if (game.State != GameState.InProgress)
        {
            return (false, "Helaas, het spel zit er al op");
        }

        if (game.GuessedLetters.Contains(letter))
        {
            return (false, $"De letter {letter} heb je al geprobeerd, probeer een andere!");
        }

        return (true, null);
    }

    public bool HasWordBeenGuessed(GameEntity game)
    {
        foreach (var l in game.WordToGuess)
        {
            if (!game.GuessedLetters.Contains(l))
            {
                return false;
            }
        }

        return true;
    }
}