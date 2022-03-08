using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
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
                throw new FormatException("Sqrt function problem!");
            }

            return Math.Sqrt(eq.Calculate());
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
