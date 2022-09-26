using BowlingGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BowlingGame.UnitTests
{
  [TestClass]
  public class GameParameterizedTests : GameBaseTest
  {
    [DataTestMethod]
    [DataRow(0, 20, 0)]
    [DataRow(1, 20, 20)]
    [DataRow(10, 12, 300)]
    public void DataRow_Games(int pins, int rolls, int score)
    {
      RollBall(pins, rolls);
      Assert.AreEqual(score, _game.GetScore());
    }

    [DataTestMethod]
    [DynamicData(nameof(GetGamesData), DynamicDataSourceType.Method)]
    public void DynamicData_Games(int pins, int rolls, int score)
    {
      RollBall(pins, rolls);
      Assert.AreEqual(score, _game.GetScore());
    }

    public static IEnumerable<object[]> GetGamesData()
    {
      yield return new object[] { 0, 20, 0 };
      yield return new object[] { 1, 20, 20 };
      yield return new object[] { 10, 12, 300 };
    }
  }
}


