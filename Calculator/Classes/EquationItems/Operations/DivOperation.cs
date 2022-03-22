using System.Collections.Generic;

namespace Calculator
{
    public class DivOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, -1, "div operation");
            double rightNum = GetNum(EqItems, 1, "div operation");

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
