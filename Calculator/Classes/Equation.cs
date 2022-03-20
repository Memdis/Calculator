using System.Collections.Generic;

namespace Calculator
{
    public class Equation : IEquation
    {
        public List<object> Items { get; set; }
        public int Index { get; set; }

        public Equation(List<object> items)
        {
            Items = items;
        }
    }
}
