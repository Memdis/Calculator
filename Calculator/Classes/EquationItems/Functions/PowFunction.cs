using System;
using System.Collections.Generic;

namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBase
    {
        public IEquation BaseEquation { get ; set ; }

        public double Execute(List<object> EqItems)
        {
            double numBase = GetNum(EqItems, -1, "pow function");
            double num = GetNum(EqItems, 1, "pow function");
            
            return Math.Pow(numBase, num);
        }

        public override string GetStringRepresentation()
        {
            return "^";
        }

        public IFunction NewInstance()
        {
            return new PowFunction();
        }
    }
}
