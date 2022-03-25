using System.Collections.Generic;

namespace Calculator
{
    public static class ExecutableItems
    {
        private static readonly List<EquationItem> _allExeEqItems = new List<EquationItem>();
        static ExecutableItems()
        {
            List<IOperation> _allowedOperations = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            List<IFunction> _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            foreach (var operation in _allowedOperations)
            {
                _allExeEqItems.Add((EquationItem)operation);
            }
            foreach (var function in _allowedFunctions)
            {
                _allExeEqItems.Add((EquationItem)function);
            }
        }

        public static List<EquationItem> Get()
        {
            return _allExeEqItems;
        }
    }
}
