using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : EquationItem, IFunction
    {
        public TanFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);

            if (Settings.AngleUnits == AngleUnits.Deg)
            {
                return Math.Tan(num.DegToRad());
            }
            else
            {
                return Math.Tan(num);
            }
        }

        public override string GetStringRepresentation()
        {
            return "tan";
        }

        public IFunction NewInstance()
        {
            return new TanFunction(Type);
        }
    }
}
