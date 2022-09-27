using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    public class Calculator
    {
        // unit

        public int Multiply(int x, int y)
        {
            if (x > 4)
            {
                return x * y;
            }

            return 4 * x;
        }


        public int ImpossibleCalculation()
        {
            throw new NotImplementedException("Ga weg");
        }

        private int DoSomethingMagical(int i)
        {
            return 42 + i;
        }
    }
}