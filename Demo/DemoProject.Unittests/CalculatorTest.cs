using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DemoProject.Unittests
{
	[TestClass]
	public class CalculatorTest
	{

		[TestMethod]
		//[ExpectedException(typeof(NotImplementedException))]
		public void ImpossibleCalculation_ThrowsNotImplException()
		{
			var sut = new Calculator();
			//sut.ImpossibleCalculation();
			Assert.ThrowsException<NotImplementedException>(() => sut.ImpossibleCalculation());
		}


		[TestMethod]
		public void Multiply_TwoPositiveIntegers_MultipliedResult()
		{
			// Arrange: setup
			var sut = new Calculator(); // system under test

			// Act
			var result = sut.Multiply(4, 8); // hongaarse notatie
			//sut.DoSomethingMagical(3);

			// Assert: toetsingen
			Assert.AreEqual(16, result);
		}

		[TestMethod]
		public void Nothing_StillNothing_JustLearning()
		{
			Assert.AreEqual("hoi", "hoi");
			Assert.AreEqual(42, 42);
			Assert.AreNotEqual(4, 8);
			Assert.Fail();

		}

		[TestMethod]
		[Timeout(4000)]
		public void Whatevah()
		{
			Assert.IsTrue(false);
			
		}

		[TestMethod]
		[TestCategory("awesome")]
		public void Trait1()
		{

		}

		[TestMethod]
		[TestCategory("saai")]
		public void Trait2()
		{

		}

		[TestMethod]
		[TestCategory("awesome")]
		public void Trait3()
		{

		}
	}
}