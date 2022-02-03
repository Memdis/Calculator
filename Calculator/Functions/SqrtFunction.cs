using System;

namespace Calculator
{
    public class SqrtFunction : IFunction
    {
        public IEquation Equation { get; set; }
        public int Index { get; set; }

        /*public void SetEquation(IEquation equation)
        {
            Equation = equation;
        }*/

        public double Execute()
        {
            return Math.Sqrt(Equation.Calculate());
        }

        public int GetPriority()
        {
            return 2;
        }

        public string GetStringRepresentation()
        {
            return "sqrt";
        }

        public IFunction NewFunction()
        {
            return new SqrtFunction();
        }
    }
}
