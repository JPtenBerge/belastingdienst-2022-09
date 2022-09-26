using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCalc.Lib
{
	public class Calculator
	{
		IOperation _operation;

		public Calculator(IOperation operation)
		{
			_operation = operation;
		}

		public double Execute(double arg1, double arg2)
		{
			return _operation.PerformOperation(arg1, arg2);
		}
	}
}
