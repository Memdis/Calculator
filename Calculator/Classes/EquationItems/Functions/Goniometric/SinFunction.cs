using System;
using ExtensionMethods;

namespace Calculator
{
    public class SinFunction : ExecutableEquationItem, IFunction
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
                throw new FormatException("Sin function problem!");
            }

            double result = eq.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Sin(result.DegToRad());
            }
            else
            {
                return Math.Sin(result);
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
