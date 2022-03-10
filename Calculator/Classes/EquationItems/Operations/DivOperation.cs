using System;

namespace Calculator
{
    public class DivOperation : ExecutableEquationItem, IOperation
    {
        public double Execute(IEquation eqFuncIsPartOf)
        {
            double leftNum;
            double rightNum;

            try
            {
                leftNum = EquationHelper.GetNumber(Index, -1, eqFuncIsPartOf);
                rightNum = EquationHelper.GetNumber(Index, 1, eqFuncIsPartOf);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input format!"); //TODO pupup window
            }

            return leftNum / rightNum;
        }

        public override int GetPriority()
        {
            return 1;
        }

        public override string GetStringRepresentation()
        {
            return "/";
        }

        public IOperation NewInstance()
        {
            return new DivOperation();
        }
    }
}
