using Xunit;

namespace DemoProject.xUnit
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			Assert.Equal(14, 14);
			Assert.Equal("hoi", "doei");
		}
	}
}