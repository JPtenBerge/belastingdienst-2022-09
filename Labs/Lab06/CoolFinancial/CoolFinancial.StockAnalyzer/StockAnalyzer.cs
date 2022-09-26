namespace CoolFinancial
{
  public enum Analysis { Buy, Hold, Sell, Error };

  public interface IStockFeed
  {
    decimal GetSharePrice(string company);
  }
  public class StockAnalyzer
  {
    private IStockFeed stockFeed;
    public StockAnalyzer(IStockFeed feed)
    {
      stockFeed = feed;
    }
    public Analysis GetStockAnalysis(string symbol)
    {
      decimal price = stockFeed.GetSharePrice(symbol);

      switch (symbol.ToUpper())
      {
        case "CTSO":
          {
            if (price < 10)
              return Analysis.Buy;
            else if (price > 20)
              return Analysis.Sell;
            else
              return Analysis.Hold;
          }
        case "NWND":
          {
            if (price < 50)
              return Analysis.Buy;
            else if (price > 100)
              return Analysis.Sell;
            else
              return Analysis.Hold;
          }
      }
      return Analysis.Error;
    }
  }
}