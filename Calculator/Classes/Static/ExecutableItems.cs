using System.Collections.Generic;

namespace Calculator
{
    public static class ExecutableItems
    {
        private static readonly List<ExecutableEquationItem> _allExeEqItems = new List<ExecutableEquationItem>();
        static ExecutableItems()
        {
            List<IOperation> _allowedOperations = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            List<IFunction> _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            foreach (var operation in _allowedOperations)
            {
                _allExeEqItems.Add((ExecutableEquationItem)operation);
            }
            foreach (var function in _allowedFunctions)
            {
                _allExeEqItems.Add((ExecutableEquationItem)function);
            }
        }

        public static List<ExecutableEquationItem> Get()
        {
            return _allExeEqItems;
        }
    }
}
