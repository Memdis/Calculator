using System;
using System.Collections.Generic;

namespace Calculator
{
    public class ExecutableEquationItem
    {
        public int Index { get; set; }
        public virtual int GetPriority()
        {
            return ExeEqItemHelper.GetPriority(this);
        }

        public virtual string GetStringRepresentation()
        {
            return "String representation not implemented";
        }

        protected double GetNum(List<object> eqItems, int indexShift, string errorMessage)
        {
            double num;

            try
            {
                num = ExeEqItemHelper.GetNumber(Index, indexShift, eqItems);
            }
            catch
            {
                throw new FormatException($"Formatting problem in {errorMessage}!");
            }

            return num;
        }
    }
}
