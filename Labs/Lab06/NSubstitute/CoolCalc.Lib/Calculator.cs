namespace CoolCalc
{
  public class Calculator
  {
    IOperation _operation;

    public Calculator(IOperation operation)
    {
      _operation = operation;
    }

    public virtual double Execute(double arg1, double arg2)
    {
      return _operation.PerformOperation(arg1, arg2);
    }
  }
}
