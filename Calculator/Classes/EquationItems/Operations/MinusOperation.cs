using System;

namespace Calculator
{
    public class MinusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double leftNum = GetNum(eqWhereFunctionBelongs, -1, "minus operation");
            double rightNum = GetNum(eqWhereFunctionBelongs, 1, "minus operation");

            return leftNum - rightNum;
        }
        public override string GetStringRepresentation()
        {
            return "-";
        }

        public IOperation NewInstance()
        {
            return new MinusOperation();
        }
    }
}
