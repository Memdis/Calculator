using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class SinFunction : EquationItem, IFunction
    {
        public SinFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);

            if (Settings.AngleUnits == AngleUnits.Deg)
            {
                return Math.Sin(num.DegToRad());
            }
            else
            {
                return Math.Sin(num);
            }
        }

        public override string GetStringRepresentation()
        {
            return "sin";
        }

        public IFunction NewInstance()
        {
            return new SinFunction(Type);
        }
    }
}
