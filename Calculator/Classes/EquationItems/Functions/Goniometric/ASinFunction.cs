using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class ASinFunction : EquationItem, IFunction
    {
        public ASinFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);
            double result = Math.Asin(num);

            if (Settings.AngleUnits == AngleUnits.Deg)
            {
                return result.RadToDeg();
            }
            else
            {
                return result;
            }
        }

        public override string GetStringRepresentation()
        {
            return "asin";
        }

        public IFunction NewInstance()
        {
            return new ASinFunction(Type);
        }
    }
}
