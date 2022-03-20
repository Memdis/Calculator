using System.Collections.Generic;


namespace Calculator
{
    public interface IEquation
    {
        List<object> Items { get; set; }
        double Calculate();
        string GetStringResult();
        int Index { get; set; }
    }
}
