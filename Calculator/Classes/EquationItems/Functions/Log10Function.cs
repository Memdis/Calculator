using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Log10Function : ExecutableEquationItem, IFunction
    {
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, 1, "log function");

            return Math.Log10(num);
        }

        public override string GetStringRepresentation()
        {
            return "log";
        }

        public IFunction NewInstance()
        {
            return new Log10Function();
        }
    }
}
