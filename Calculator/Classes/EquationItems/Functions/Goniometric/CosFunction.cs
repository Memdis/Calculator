using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : EquationItem, IFunction
    {
        public CosFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);

            if (Settings.AngleUnits == AngleUnits.Deg)
            {
                return Math.Cos(num.DegToRad());
            }
            else
            {
                return Math.Cos(num);
            }
        }

        public override string GetStringRepresentation()
        {
            return "cos";
        }

        public IFunction NewInstance()
        {
            return new CosFunction(Type);
        }
    }
}
