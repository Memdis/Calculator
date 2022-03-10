namespace Calculator
{
    public interface IOperation
    {
        double Execute(IEquation eqFuncIsPartOf);
        string GetStringRepresentation();
        int GetPriority();
        int Index { get; set; }
        IOperation NewInstance();
    }
}
