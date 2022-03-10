using System;

namespace Calculator
{
    public class PlusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double leftNum = GetNum(eqWhereFunctionBelongs, -1, "plus operation");
            double rightNum = GetNum(eqWhereFunctionBelongs, 1, "plus operation");

            return leftNum + rightNum;
        }

        public override string GetStringRepresentation()
        {
            return "+";
        }

        public IOperation NewInstance()
        {
            return new PlusOperation();
        }
    }
}
