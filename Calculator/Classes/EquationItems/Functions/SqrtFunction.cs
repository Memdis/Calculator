using System;

namespace Calculator
{
    public class SqrtFunction : ExecutableEquationItem, IFunction
    {
        public IEquation Equation { get; set; }
        public double Execute()
        {
            return Math.Sqrt(Equation.Calculate());
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
