namespace Calculator
{
    public class MultOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
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
