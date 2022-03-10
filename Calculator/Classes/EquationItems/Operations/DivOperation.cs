using System;

namespace Calculator
{
    public class DivOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double leftNum = GetNum(eqWhereFunctionBelongs, -1, "div operation");
            double rightNum = GetNum(eqWhereFunctionBelongs, 1, "div operation");

            return leftNum / rightNum;
        }

        public override int GetPriority()
        {
            return 1;
        }

        public override string GetStringRepresentation()
        {
            return "/";
        }

        public IOperation NewInstance()
        {
            return new DivOperation();
        }
    }
}
