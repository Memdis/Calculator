using System;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            double num;

            try
            {
                num = EquationHelper.GetNumber(Index, 1, eqFuncIsPartOf);
            }
            catch (Exception)
            {
                throw new FormatException("Tan function problem!");
            }

            if (Settings.UnitOfAngles == AngleUnit.Deg)
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
