using System.Collections.Generic;


namespace Calculator
{
    public interface IEquation
    {
        List<object> Items { get; }
        double Calculate();
        int Index { get; set; }
    }
}
