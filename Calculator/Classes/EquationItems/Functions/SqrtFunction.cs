using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            var eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
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
