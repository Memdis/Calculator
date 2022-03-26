using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;

namespace Calculator
{
    public class EquationItem
    {
        public int Index { get; set; }
        public FunctionType Type { get; protected set; }
        public virtual int GetPriority()
        {
            return EqItemHelper.GetPriority(this);
        }

        public virtual string GetStringRepresentation()
        {
            return "String representation not implemented";
        }

        protected static double GetNum(List<object> eqItems, int index, int indexShift)
        {
            int numIndex = index + indexShift;

            try
            {
                var number = eqItems[numIndex];

                if (number is IEquation)
                {
                    return ((IEquation)number).Calculate();
                }
                else if (number is double)
                {
                    return (double)number;
                }

                throw new FormatException();
            }
            catch
            {
                throw new FormatException($"Problem in {new StackFrame(1).GetMethod().DeclaringType}");
            }
        }
    }
}
