namespace Calculator
{
    public interface IFunction
    {
        double Execute();
        string GetStringRepresentation();
        int GetPriority();
        int Index { get; set; }
        IFunction NewInstance();
        public IEquation Equation { get; set; }
    }
}
