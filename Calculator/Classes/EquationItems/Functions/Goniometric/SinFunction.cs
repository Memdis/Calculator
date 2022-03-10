using System;
using ExtensionMethods;

namespace Calculator
{
    public class SinFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double num = GetNum(eqWhereFunctionBelongs, 1, "sin function");

            if (Settings.UnitOfAngles == AngleUnit.Deg)
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
            return new SinFunction();
        }
    }

}
