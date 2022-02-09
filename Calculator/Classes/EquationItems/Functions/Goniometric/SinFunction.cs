using System;
using ExtensionMethods;

namespace Calculator
{
    public class SinFunction : ExecutableEquationItem, IFunction
    {
        public IEquation Equation { get; set; }
        public double Execute()
        {
            double eQResult = Equation.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Sin(eQResult.DegToRad());
            }
            else
            {
                return Math.Sin(eQResult);
            }
        }

        public string GetStringRepresentation()
        {
            return "sin";
        }

        public IFunction NewInstance()
        {
            return new SinFunction();
        }
    }

}
