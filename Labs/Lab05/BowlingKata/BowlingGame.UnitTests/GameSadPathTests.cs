using System;
using System.Collections.Generic;
using System.Text;
using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.UnitTests
{
  [TestClass]
  public class GameSadPathTests : GameBaseTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Should_get_exception_when_rolling_too_many_pins()
    {
      _game.Roll(11);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Should_get_exception_when_rolling_too_few_pins()
    {
      _game.Roll(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Should_get_exception_when_rolling_too_many_times()
    {
      RollBall(3, 22);
    }
  }
}
