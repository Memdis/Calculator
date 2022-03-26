using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Log10Function : EquationItem, IFunction
    {
        public Log10Function(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);

            return Math.Log10(num);
        }

        public override string GetStringRepresentation()
        {
            return "log";
        }

        public IFunction NewInstance()
        {
            return new Log10Function(Type);
        }
    }
}
