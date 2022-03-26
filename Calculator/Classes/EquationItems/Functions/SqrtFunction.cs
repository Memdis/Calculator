using System;
using System.Collections.Generic;

namespace Calculator
{
    public class SqrtFunction : EquationItem, IFunction
    {
        public SqrtFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);
            return Math.Sqrt(num);
        }

        public override string GetStringRepresentation()
        {
            return "sqrt";
        }

        public IFunction NewInstance()
        {
            return new SqrtFunction(Type);
        }
    }
}
