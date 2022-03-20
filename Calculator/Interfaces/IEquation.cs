using System.Collections.Generic;


namespace Calculator
{
    public interface IEquation
    {
        List<object> Items { get; set; }
        int Index { get; set; }
    }
}
