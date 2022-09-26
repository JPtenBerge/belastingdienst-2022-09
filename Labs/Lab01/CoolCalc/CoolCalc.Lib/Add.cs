namespace CoolCalc.Lib
{
    public class Add : IOperation
    {
        #region IOperation Members

        public double PerformOperation(double arg1, double arg2)
        {
            return arg1 + arg2;
        }

        public string Symbol
        {
            get { return "+"; }
        }

        #endregion
    }
}