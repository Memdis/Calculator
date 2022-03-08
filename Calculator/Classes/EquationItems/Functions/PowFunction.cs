using System;
namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBaseEq
    {
        public IEquation BaseEquation { get ; set ; }

        public double Execute(IEquation eqFuncIsPartOf)//TODO eqFuncIsPartOf je fakt blbý názov, zmeniť
        {
            IEquation eqBase;
            IEquation eq;

            try
            {
                eqBase = EquationHelper.GetEquation(Index, -1, eqFuncIsPartOf);
                eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
            }
            catch (Exception)
            {
                throw new FormatException("Pow function problem!"); //TODO popup window
            }
            
            return Math.Pow(eqBase.Calculate(), eq.Calculate());
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
