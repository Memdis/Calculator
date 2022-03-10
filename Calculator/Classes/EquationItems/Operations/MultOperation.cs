using System;

namespace Calculator
{
    public class MultOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(IEquation eqWhereFunctionBelongs)
        {
            double leftNum = GetNum(eqWhereFunctionBelongs, -1, "mult operation");
            double rightNum = GetNum(eqWhereFunctionBelongs, 1, "mult operation");

            return leftNum * rightNum;
        }

        public override int GetPriority()
        {
            return 1;
        }

        public override string GetStringRepresentation()
        {
            return "*";
        }

        public IOperation NewInstance()
        {
            return new MultOperation();
        }
    }
}
