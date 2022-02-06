namespace Calculator
{
    public interface IFunctionBaseEq : IFunction
    {
        public IEquation BaseEquation { get; set; }
    }
}
