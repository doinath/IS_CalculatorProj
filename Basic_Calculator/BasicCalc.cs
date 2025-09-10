using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Calculator
{
    internal class BasicCalc : InterfaceCalcu
    {
        public double add(double a, double b) => a + b;

        public double divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero!");

            return a / b;
        }

        public double multiply(double a, double b) => a * b;

        public double subtract(double a, double b) => a - b;
    }
}
