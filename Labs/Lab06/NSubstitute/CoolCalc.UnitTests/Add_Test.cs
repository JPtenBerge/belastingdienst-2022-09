using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCalc
{
  [TestClass()]
  public class Add_Test
  {
    [TestMethod()]
    public void Should_return_4_for_2_plus_2()
    {
      Add add = new Add();
      Assert.AreEqual(4, add.PerformOperation(2, 2));
    }
  }
}