using System;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double num = GetNum(eqWhereFunctionBelongs, 1, "tan function");

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
            return new TanFunction();
        }
    }
}
