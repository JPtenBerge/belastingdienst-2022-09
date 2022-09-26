using CoolCalc.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolCalc.Tests
{
	[TestClass]
	public class AddTests
	{
		[TestMethod]
		public void PerformOperationTest()
		{
			Add target = new Add();
			double arg1 = 2;
			double arg2 = 3;
			double expected = 5;
			double actual;
			actual = target.PerformOperation(arg1, arg2);
			Assert.AreEqual(expected, actual);
		}
	}
}