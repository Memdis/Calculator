namespace Calculator
{
    public interface IFunction
    {
        double Execute(IEquation eqFuncIsPartOf);
        string GetStringRepresentation();
        int GetPriority();
        int Index { get; set; }
        IFunction NewInstance();
    }
}
