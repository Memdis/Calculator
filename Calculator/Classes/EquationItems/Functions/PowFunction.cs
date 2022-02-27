using System;
namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBaseEq
    {
        public IEquation Equation { get ; set; }
        public IEquation BaseEquation { get ; set ; }

        public double Execute()
        {
            return Math.Pow(BaseEquation.Calculate(), Equation.Calculate());
        }

        public override string GetStringRepresentation()
        {
            return "^";
        }

        public IFunction NewInstance()
        {
            return new PowFunction();
        }
    }
}
