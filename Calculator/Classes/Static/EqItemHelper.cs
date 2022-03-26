using System;
using System.Collections.Generic;

namespace Calculator
{
    public static class EqItemHelper
    {
        public static double GetNumber(int StartIndex, int IndexShift, List<object> EqItems)
        {
            int numIndex = StartIndex + IndexShift;

            if (EqItems == null)
            {
                throw new ArgumentNullException("Equation is null!");
            }

            if (EqItems.Count <= numIndex)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            var num = EqItems[numIndex];

            if (num is IEquation)
            {
                return ((IEquation)num).Calculate();
            }
            else if (num is double)
            {
                return (double)num;
            }

            throw new FormatException("Expected equation or double but received something else!");
        }
        public static int GetPriority(EquationItem item)
        {
            if (item.Type == FunctionType.Operation)
            {
                return 0;
            }
            else if (item.Type == FunctionType.Function)
            {
                return 2;
            }

            return 1;
        }
    }
}
