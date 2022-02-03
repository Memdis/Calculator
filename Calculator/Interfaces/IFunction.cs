namespace Calculator
{
    public interface IFunction
    {
        double Execute();
        string GetStringRepresentation();
        int GetPriority();
        IFunction NewFunction();
        public IEquation Equation { get; set; }
        int Index { get; set; }
    }
}
