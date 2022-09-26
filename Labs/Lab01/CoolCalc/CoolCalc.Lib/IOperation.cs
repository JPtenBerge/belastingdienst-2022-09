using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCalc.Lib
{
	public interface IOperation
	{
		double PerformOperation(double arg1, double arg2);
		string Symbol { get; }
	}
}
