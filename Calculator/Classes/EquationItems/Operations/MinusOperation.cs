using System.Collections.Generic;

namespace Calculator
{
    public class MinusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, -1, "minus operation");
            double rightNum = GetNum(EqItems, 1, "minus operation");

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
