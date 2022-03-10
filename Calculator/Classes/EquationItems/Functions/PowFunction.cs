using System;
namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBaseEq
    {
        public IEquation BaseEquation { get ; set ; }

        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double numBase = GetNum(eqWhereFunctionBelongs, -1, "pow function");
            double num = GetNum(eqWhereFunctionBelongs, 1, "pow function");
            
            return Math.Pow(numBase, num);
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
