using System;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : ExecutableEquationItem, IFunction
    {
        public IEquation Equation { get; set; }
        public double Execute()
        {
            double eQResult = Equation.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Cos(eQResult.DegToRad());
            }
            else
            {
                return Math.Cos(eQResult);
            }
        }

        public string GetStringRepresentation()
        {
            return "cos";
        }

        public IFunction NewInstance()
        {
            return new CosFunction();
        }
    }


}
