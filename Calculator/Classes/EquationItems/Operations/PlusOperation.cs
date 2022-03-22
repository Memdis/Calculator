using System.Collections.Generic;

namespace Calculator
{
    public class PlusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, -1, "plus operation");
            double rightNum = GetNum(EqItems, 1, "plus operation");

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
