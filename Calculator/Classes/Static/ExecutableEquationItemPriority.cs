namespace Calculator
{
    public static class ExecutableEquationItemPriority
    {
        public static int GetPriority(ExecutableEquationItem item)
        {
            if (item is IOperation)
            {
                return 0;
            }
            else if (item is IFunction)
            {
                return 2;
            }

            return 1;
        }
    }
}
