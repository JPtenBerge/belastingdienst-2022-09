using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCalc
{
  [TestClass()]
  public class Multiply_Test
  {
    [TestMethod()]
    public void Should_return_4_for_2_times_2()
    {
      var multiply = new Multiply();
      Assert.AreEqual(4, multiply.PerformOperation(2, 2));
    }
  }
}