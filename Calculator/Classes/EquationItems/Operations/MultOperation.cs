using System.Collections.Generic;

namespace Calculator
{
    public class MultOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, -1, "mult operation");
            double rightNum = GetNum(EqItems, 1, "mult operation");

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
