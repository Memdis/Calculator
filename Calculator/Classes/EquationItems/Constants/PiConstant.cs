using System;
using System.Collections.Generic;

namespace Calculator
{
    public class PiConstant : EquationItem, IFunction
    {
        public PiConstant(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            if (Settings.AngleUnits == AngleUnits.Rad)
            {
                return Math.PI;
            }
            else
            {
                return 90;
            }
        }
        public override string GetStringRepresentation()
        {
            return "pi";
        }

        public IFunction NewInstance()
        {
            return new PiConstant(Type);
        }
    }
}
