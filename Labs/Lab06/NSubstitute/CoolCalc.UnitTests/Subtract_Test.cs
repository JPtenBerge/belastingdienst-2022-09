using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCalc
{
  [TestClass()]
  public class Subtract_Test
  {
    [TestMethod()]
    public void Should_return_0_for_2_minus_2()
    {
      var subtract = new Subtract();
      Assert.AreEqual(0, subtract.PerformOperation(2, 2));
    }
  }
}