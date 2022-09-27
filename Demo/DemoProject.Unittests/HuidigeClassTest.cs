using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DemoProject.Unittests;

[TestClass]
public class HuidigeClassTest
{
    [TestMethod]
    public void Get()
    {
        var sut = new HuidigeClass();
        var result = sut.Get();

        using (ShimsContext.Create())
		{
            

        }

            Assert.AreEqual("15:10:49", result);

        
    }
}