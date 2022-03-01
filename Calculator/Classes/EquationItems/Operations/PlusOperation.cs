namespace Calculator
{
    public class PlusOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }

        public override string GetStringRepresentation()
        {
            return "+";
        }

        public IOperation NewInstance()
        {
            return new PlusOperation();
        }
    }
}
