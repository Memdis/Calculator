using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        public string Calculate(string inputString)
        {
            var equation = EquationHelper.ExtractItems(inputString);

            double result = equation.Calculate();

            return result.ToString();
        }
    }
}
