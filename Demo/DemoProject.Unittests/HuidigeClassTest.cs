using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using System.fakes;

namespace DemoProject.Unittests;

[TestClass]
public class HuidigeClassTest
{
	[TestMethod]
	public void Get()
	{
		var sut = new HuidigeClass();

		using (ShimsContext.Create())
		{
			System.Fakes.ShimDateTime.NowGet = () => new DateTime(2022, 9, 27, 15, 10, 49);
			var result = sut.Get();
			Assert.AreEqual("15:10:49", result);
		}
	}
}
