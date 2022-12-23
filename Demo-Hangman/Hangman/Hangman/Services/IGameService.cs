using Hangman.Shared;

namespace Hangman.Services;

public interface IGameService
{
    (bool, string?) IsValidGuess(GameEntity game, string letter);
    bool HasWordBeenGuessed(GameEntity game);
}