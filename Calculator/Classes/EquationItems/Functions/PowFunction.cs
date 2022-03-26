using System;
using System.Collections.Generic;

namespace Calculator
{
    public class PowFunction : EquationItem, IFunctionBase
    {
        public PowFunction(FunctionType type)
        {
            Type = type;
        }
        public IEquation BaseEquation { get ; set ; }

        public double Execute(List<object> EqItems)
        {
            double numBase = GetNum(EqItems, Index, -1);
            double num = GetNum(EqItems, Index, 1);
            
            return Math.Pow(numBase, num);
        }

        public override string GetStringRepresentation()
        {
            return "^";
        }

        public IFunction NewInstance()
        {
            return new PowFunction(Type);
        }
    }
}
