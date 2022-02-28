using System;
using ExtensionMethods;

namespace Calculator
{
    public class TanFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            var eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
            double result = eq.Calculate();

            if (Settings.UnitOfAngles == AngleUnit.Deg)
            {
                return Math.Tan(result.DegToRad());
            }
            else
            {
                return Math.Tan(result);
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
