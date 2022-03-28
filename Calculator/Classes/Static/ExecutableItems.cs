using System.Collections.Generic;

namespace Calculator
{
    public static class ExecutableItems
    {
        private static readonly List<EquationItem> _allExeEqItems = new List<EquationItem>();
        static ExecutableItems()
        {
            _allExeEqItems = new List<EquationItem>() { new PlusOperation(FunctionType.Operation), new MinusOperation(FunctionType.Operation), 
                new MultOperation(FunctionType.Operation), new DivOperation(FunctionType.Operation),
                new Log10Function(FunctionType.Function), new SqrtFunction(FunctionType.Function), new PowFunction(FunctionType.Function), 
                new SinFunction(FunctionType.Function), new CosFunction(FunctionType.Function), new TanFunction(FunctionType.Function), 
                new ASinFunction(FunctionType.Function), new ACosFunction(FunctionType.Function), new ATanFunction(FunctionType.Function),
                new PiConstant(FunctionType.Constant), new EConstant(FunctionType.Constant) };
        }

        public static List<EquationItem> Get()
        {
            return _allExeEqItems;
        }
    }
}
