using System;
namespace Calculator
{
    public class PowFunction : ExecutableEquationItem, IFunctionBaseEq
    {
        public IEquation BaseEquation { get ; set ; }

        public double Execute(IEquation eqFuncIsPartOf)
        {
            var eqBase = EquationHelper.GetEquation(Index, -1, eqFuncIsPartOf);
            var eq = EquationHelper.GetEquation(Index, 1, eqFuncIsPartOf);
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
