using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            double num = GetNum(eqFuncIsPartOf, 1, "sqrt function");

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
