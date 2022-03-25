using System.Collections.Generic;

namespace Calculator
{
    public class MinusOperation : EquationItem, IOperation
    {
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, Index, -1);
            double rightNum = GetNum(EqItems, Index, 1);

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
