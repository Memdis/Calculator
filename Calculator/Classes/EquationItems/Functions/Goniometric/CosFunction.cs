using System;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            IEquation eq;

            try
            {
                eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
            }
            catch (Exception)
            {
                throw new FormatException("Cos function problem!");
            }

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
