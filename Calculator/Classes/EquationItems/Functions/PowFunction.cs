using System;
namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBaseEq
    {
        public IEquation BaseEquation { get ; set ; }

        public double Execute(IEquation eqFuncIsPartOf)//TODO eqFuncIsPartOf je fakt blbý názov, zmeniť
        {
            double numBase;
            double num;

            try
            {
                numBase = EquationHelper.GetNumber(Index, -1, eqFuncIsPartOf);
                num = EquationHelper.GetNumber(Index, 1, eqFuncIsPartOf);
            }
            catch (Exception)
            {
                throw new FormatException("Pow function problem!"); //TODO popup window
            }
            
            return Math.Pow(numBase, num);
        }

        public override string GetStringRepresentation()
        {
            return "^";
        }

        public IFunction NewInstance()
        {
            return new PowFunction();
        }
    }
}
