using System;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            var eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
            double result = eq.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Cos(result.DegToRad());
            }
            else
            {
                return Math.Cos(result);
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
