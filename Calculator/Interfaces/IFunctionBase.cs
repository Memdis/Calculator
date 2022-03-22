namespace Calculator
{
    public interface IFunctionBase : IFunction
    {
        public IEquation BaseEquation { get; set; }
    }
}
