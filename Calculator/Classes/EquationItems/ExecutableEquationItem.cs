using System;

namespace Calculator
{
    public class ExecutableEquationItem
    {
        public int Index { get; set; }
        public virtual int GetPriority()
        {
            return ExecutableEquationItemPriority.GetPriority(this);
        }

        public virtual string GetStringRepresentation()
        {
            return "String representation not implemented";
        }

        protected double GetNum(IEquation eqFuncIsPartOf, int indexShift, string errorMessage)
        {
            double num;

            try
            {
                num = EquationHelper.GetNumber(Index, indexShift, eqFuncIsPartOf);
            }
            catch
            {
                throw new FormatException($"Formatting problem in {errorMessage}!");
            }

            return num;
        }
    }
}
