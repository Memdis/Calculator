using System.Collections.Generic;

namespace Calculator.UnitTests
{
    public class TestSetupAndTearDown
    {
        public void SetUp(AngleUnits angleUnits, string decimalSeparator)
        {
            Settings.SaveSettings((int)angleUnits, decimalSeparator);

            List<IOperation> _allowedOperations = new List<IOperation>() { new PlusOperation(), new MinusOperation(), new MultOperation(), new DivOperation() };
            List<IFunction> _allowedFunctions = new List<IFunction>() { new Log10Function(), new SqrtFunction(), new PowFunction(), new SinFunction(), new CosFunction(), new TanFunction() };

            List<ExecutableEquationItem> allExeEqItems = new List<ExecutableEquationItem>();
            List<string> allExeEqItemsRepresentation = new List<string>();

            foreach (var operation in _allowedOperations)
            {
                allExeEqItems.Add((ExecutableEquationItem)operation);
                allExeEqItemsRepresentation.Add(operation.GetStringRepresentation());
            }
            foreach (var function in _allowedFunctions)
            {
                allExeEqItems.Add((ExecutableEquationItem)function);
                allExeEqItemsRepresentation.Add(function.GetStringRepresentation());
            }

            ExecutableFunctions.AllExeEqItems.AddRange(allExeEqItems);
            ExecutableFunctions.AllExeEqItemsRepresentation.AddRange(allExeEqItemsRepresentation);
        }

        public void TearDown()
        {
            ExecutableFunctions.AllExeEqItems.Clear();
            ExecutableFunctions.AllExeEqItemsRepresentation.Clear();
        }
    }
}