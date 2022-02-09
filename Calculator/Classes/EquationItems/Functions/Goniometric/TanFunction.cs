using System;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : ExecutableEquationItem, IFunction
    {
        public IEquation Equation { get; set; }
        public double Execute()
        {
            double eQResult = Equation.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Tan(eQResult.DegToRad());
            }
            else
            {
                return Math.Tan(eQResult);
            }
        }

        public string GetStringRepresentation()
        {
            return "tan";
        }

        public IFunction NewInstance()
        {
            return new TanFunction();
        }
    }



}
