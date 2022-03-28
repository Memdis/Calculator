using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class ATanFunction : EquationItem, IFunction
    {
        public ATanFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);
            double result = Math.Atan(num);

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
            return "atan";
        }

        public IFunction NewInstance()
        {
            return new ATanFunction(Type);
        }
    }
}
