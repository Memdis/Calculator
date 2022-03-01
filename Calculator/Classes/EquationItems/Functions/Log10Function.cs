using System;

namespace Calculator
{
    public class Log10Function : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            var eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
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
