using System.Collections.Generic;

namespace Calculator
{
    public class DivOperation : EquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, Index, -1);
            double rightNum = GetNum(EqItems, Index, 1);

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
