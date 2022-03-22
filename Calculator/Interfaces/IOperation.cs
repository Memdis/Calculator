using System.Collections.Generic;

namespace Calculator
{
    public interface IOperation
    {
        double Execute(List<object> EqItems);
        string GetStringRepresentation();
        int GetPriority();
        int Index { get; set; }
        IOperation NewInstance();
    }
}
