using System;

namespace Calculator
{
    public class Log10Function : IFunction
    {
        public IEquation Equation { get; set; }
        public int Index { get ; set; }

        /*public void SetEquation(IEquation equation)
        {
            Equation = equation;
        }*/

        public double Execute()
        {
            return Math.Log10(Equation.Calculate());
        }

        public int GetPriority()
        {
            return 2;
        }

        public string GetStringRepresentation()
        {
            return "log";
        }

        public IFunction NewFunction()
        {
            return new Log10Function();
        }
    }
}
