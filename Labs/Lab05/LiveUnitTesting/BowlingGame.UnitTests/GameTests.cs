using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGame.UnitTests
{
  [TestClass]
  public class GameTests : GameBaseTest
  {

    [TestMethod]
    public void Should_return_0_for_all_gutterballs()
    {
      RollBall(0,20);
      Assert.AreEqual(0, _game.GetScore());
    }

    [TestMethod]
    public void Should_return_20_for_all_1s()
    {
      RollBall(1, 20);
      Assert.AreEqual(1 * 20, _game.GetScore());
    }

    [TestMethod]
    public void Should_add_next_roll_after_a_spare()
    {
      RollBall(5, 2);
      RollBall(3, 1);
      RollBall(4, 1);
      RollBall(0, 16);
      Assert.AreEqual((5 + 5 + 3) + 3 + 4, _game.GetScore());
    }

    [TestMethod]
    public void Should_add_next_2_rolls_after_a_strike()
    {
      RollBall(10, 1);
      RollBall(5, 1);
      RollBall(3, 1);
      RollBall(4, 1);
      RollBall(0, 17);
      Assert.AreEqual((10 + (5 + 3)) + (5 + 3) + 4, _game.GetScore());
    }

    [TestMethod]
    public void Should_return_300_for_a_perfect_game()
    {
      RollBall(10, 12);
      Assert.AreEqual(300, _game.GetScore());
    }
  }
}