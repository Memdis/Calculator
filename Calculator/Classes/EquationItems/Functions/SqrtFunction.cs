using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double num = GetNum(eqWhereFunctionBelongs, 1, "sqrt function");

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
