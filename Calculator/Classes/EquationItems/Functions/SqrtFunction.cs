using System;
using System.Collections.Generic;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, 1, "sqrt function");

            return Math.Sqrt(num);
        }

        public override string GetStringRepresentation()
        {
            return "sqrt";
        }

        public IFunction NewInstance()
        {
            return new SqrtFunction();
        }
    }
}
