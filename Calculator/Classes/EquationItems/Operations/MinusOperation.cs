namespace Calculator
{
    public class MinusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
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
