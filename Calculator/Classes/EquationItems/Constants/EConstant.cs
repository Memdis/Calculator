using System;
using System.Collections.Generic;

namespace Calculator
{
    public class EConstant : EquationItem, IFunction
    {
        public EConstant(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            return Math.E;
        }
        public override string GetStringRepresentation()
        {
            return "e";
        }

        public IFunction NewInstance()
        {
            return new EConstant(Type);
        }
    }
}
