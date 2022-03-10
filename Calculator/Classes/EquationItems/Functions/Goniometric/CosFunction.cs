using System;
using ExtensionMethods;

namespace Calculator
{
    public class CosFunction : ExecutableEquationItem, IFunction
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
                throw new FormatException("Cos function problem!");
            }

            if (Settings.UnitOfAngles == AngleUnit.Deg)
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
