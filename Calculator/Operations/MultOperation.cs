namespace Calculator
{
    public class MultOperation : IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }

        public int GetPriority()
        {
            return 1;
        }

        public string GetStringRepresentation()
        {
            return "*";
        }

        public int Index { get; set; }

        public IOperation NewOperation()
        {
            return new MultOperation();
        }
    }
}
