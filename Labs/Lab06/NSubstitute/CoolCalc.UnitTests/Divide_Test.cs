using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCalc
{
  [TestClass()]
  public class Divide_Test
  {
    [TestMethod()]
    public void Should_return_3_for_9_div_3()
    {
      var divide = new Divide();
      Assert.AreEqual(3, divide.PerformOperation(9, 3));
    }
  }
}