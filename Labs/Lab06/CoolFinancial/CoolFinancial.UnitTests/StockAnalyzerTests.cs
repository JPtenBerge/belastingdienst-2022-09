using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoolFinancial
{
	class ExpensiveStockFeed : IStockFeed
	{
		public decimal GetSharePrice(string symbol)
		{
			// Simulate a lengthy, costly, remote service call
			System.Threading.Thread.Sleep(5000);
			switch (symbol.ToUpper())
			{
				case "CTSO": return 8.10M;
				case "NWND": return 114.80M;
				default: return 0M;
			}
		}
	}

	[TestClass]
	public class StockAnalyzerTests
	{
		[TestMethod]
		public void Get_ContosoAnalysis_ExpectBuy()
		{
			// Arrange
			var stockFeed = new ExpensiveStockFeed();
			var stockAnalyzer = new StockAnalyzer(stockFeed);

			// Act
			var result = stockAnalyzer.GetStockAnalysis("CTSO");

			// Assert
			if (result != Analysis.Buy)
			{
				Assert.Fail(string.Format("Expected Buy, but actual was {0}", result.ToString()));
			}
		}

		[TestMethod]
		public void Get_NorthwindAnalysis_ExpectSell()
		{
			// Arrange
			var stockFeed = new ExpensiveStockFeed();
			var stockAnalyzer = new StockAnalyzer(stockFeed);

			// Act
			var result = stockAnalyzer.GetStockAnalysis("NWND");

			// Assert
			if (result != Analysis.Sell)
			{
				Assert.Fail(string.Format("Expected Buy, but actual was {0}", result.ToString()));
			}
		}
	}
}