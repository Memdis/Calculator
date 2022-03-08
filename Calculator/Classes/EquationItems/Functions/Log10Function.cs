using System;

namespace Calculator
{
    public class Log10Function : ExecutableEquationItem, IFunction
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
                throw new FormatException("Log function problem!");
            }

            return Math.Log10(eq.Calculate());
        }

        public override string GetStringRepresentation()
        {
            return "log";
        }

        public IFunction NewInstance()
        {
            return new Log10Function();
        }
    }
}
