using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, 1, "cos function");

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
            return new CosFunction();
        }
    }


}
