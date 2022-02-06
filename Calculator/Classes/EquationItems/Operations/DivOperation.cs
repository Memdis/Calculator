namespace Calculator
{
    public class DivOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }

        public override int GetPriority()
        {
            return 1;
        }

        public string GetStringRepresentation()
        {
            return "/";
        }

        public IOperation NewInstance()
        {
            return new DivOperation();
        }
    }
}
