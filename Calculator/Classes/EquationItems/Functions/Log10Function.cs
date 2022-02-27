using System;

namespace Calculator
{
    public class Log10Function : ExecutableEquationItem, IFunction
    {
        public IEquation Equation { get; set; }
        public double Execute()
        {
            return Math.Log10(Equation.Calculate());
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
