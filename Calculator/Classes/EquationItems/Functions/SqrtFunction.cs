using System;
using System.Collections.Generic;

namespace Calculator
{
    public class SqrtFunction : EquationItem, IFunction
    {
        public double Execute(List<object> EqItems)
        {
            double num = GetNum(EqItems, Index, 1);
            return Math.Sqrt(num);
            /*
            try
            {
                num = GetNumSqrt(EqItems, Index, 1);
            }
            catch (Exception)
            {
                throw new FormatException("Problem in Sqrt function!");
            }
            
            return Math.Sqrt(num);*/
        }

        public override string GetStringRepresentation()
        {
            return "sqrt";
        }

        public IFunction NewInstance()
        {
            return new SqrtFunction();
        }
    }
}
