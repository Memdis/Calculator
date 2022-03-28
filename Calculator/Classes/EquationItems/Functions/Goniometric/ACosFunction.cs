using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class ACosFunction : EquationItem, IFunction
    {
        public ACosFunction(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);
            double result = Math.Acos(num);

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
            return "acos";
        }

        public IFunction NewInstance()
        {
            return new ACosFunction(Type);
        }
    }
}
