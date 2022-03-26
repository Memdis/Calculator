using System.Collections.Generic;

namespace Calculator
{
    public interface IFunction
    {
        double Execute(List<object> EqItems);
        string GetStringRepresentation();
        int GetPriority();
        int Index { get; set; }
        public FunctionType Type { get; }
        IFunction NewInstance();
    }
}
