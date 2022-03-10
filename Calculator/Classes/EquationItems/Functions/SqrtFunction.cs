using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
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
                throw new FormatException("Sqrt function problem!");
            }

            return Math.Sqrt(num);
        }

        public override string GetStringRepresentation()
        {
            return "sqrt";
        }

        public IFunction NewInstance()
        {
            return new SqrtFunction();
        }
    }
}
