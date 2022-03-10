using System;

namespace Calculator
{
    public class Log10Function : ExecutableEquationItem, IFunction
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double num = GetNum(eqWhereFunctionBelongs, 1, "log function");

            return Math.Log10(num);
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
