using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.UnitTests
{
  public class GameBaseTest
  {
    protected Game _game;

    [TestInitialize]
    public void InitializeGame()
    {
      _game = new Game();
    }
    protected void RollBall(int pinsDown, int timesToRoll)
    {
      for (int i = 0; i < timesToRoll; i++)
      {
        _game.Roll(pinsDown);
      }
    }
  }
}

