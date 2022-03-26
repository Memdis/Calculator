using System.Collections.Generic;

namespace Calculator
{
    public class MultOperation : EquationItem, IFunction
    {
        public MultOperation(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, Index, -1);
            double rightNum = GetNum(EqItems, Index, 1);

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

        public IFunction NewInstance()
        {
            return new MultOperation(Type);
        }
    }
}
