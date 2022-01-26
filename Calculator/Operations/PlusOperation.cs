using System;

namespace Calculator
{
    public class PlusOperation : IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public int GetPriority()
        {
            return 0;
        }

        public string GetStringRepresentation()
        {
            return "+";
        }

        public int Index { get; set; }

        public IOperation NewOperation()
        {
            return new PlusOperation();
        }
    }
}
