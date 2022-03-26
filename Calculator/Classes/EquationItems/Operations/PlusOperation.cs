using System.Collections.Generic;

namespace Calculator
{
    public class PlusOperation : EquationItem, IFunction
    {
        public PlusOperation(FunctionType type)
        {
            Type = type;
        }
        public double Execute(List<object> EqItems)
        {
            double leftNum = GetNum(EqItems, Index, -1);
            double rightNum = GetNum(EqItems, Index, 1);

            return leftNum + rightNum;
        }

        public override string GetStringRepresentation()
        {
            return "+";
        }

        public IFunction NewInstance()
        {
            return new PlusOperation(Type);
        }
    }
}
