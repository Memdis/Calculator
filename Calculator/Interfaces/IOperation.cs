namespace Calculator
{
    public interface IOperation
    {
        double Execute(double firstNum, double secondNum);
        string GetRepresentation();
        int GetPriority();
        int Index { get; set; }
        IOperation NewOperation();
    }
}
