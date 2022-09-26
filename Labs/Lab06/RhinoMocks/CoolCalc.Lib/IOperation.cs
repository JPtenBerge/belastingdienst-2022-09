namespace CoolCalc
{
  public interface IOperation
  {
    double PerformOperation(double arg1, double arg2);
    string Symbol { get; }
  }
}
