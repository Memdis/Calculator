using System.Collections.Generic;
using System.Linq;
using System;

namespace Calculator
{
    public class Equation : IEquation
    {
        public List<object> Items { get; private set; }

        public Equation(List<object> items)
        {
            Items = items;
        }
        public double Calculate()
        {
            var functionsExecutedItems = ExecuteFunctions(Items);
            var functionsAndOperationsExecutedItems = ExecuteOperations(functionsExecutedItems);

            return GetEquationResult(functionsAndOperationsExecutedItems);
        }

        private static double GetEquationResult(List<object> FunctionsAndOperationsExecutedItems)
        {
            if (FunctionsAndOperationsExecutedItems.Count <= 0)
            {
                return 0;
            }

            if (FunctionsAndOperationsExecutedItems.Count > 1)
            {
                throw new FormatException("Wrong input format!");
            }

            try
            {
                if (FunctionsAndOperationsExecutedItems[0] is IEquation)
                {
                    var equation = (IEquation)FunctionsAndOperationsExecutedItems[0];
                    return Convert.ToDouble(equation.Calculate());
                }

                return Convert.ToDouble(FunctionsAndOperationsExecutedItems[0]);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input format!");
            }
        }

        private static List<object> ExecuteFunctions(List<object> EqItems)
        {
            List<object> items = new List<object>();
            items.AddRange(EqItems);

            List<IFunction> functions = GetTFromList<IFunction>(items);

            for (int i = 0; i < functions.Count; i++)
            {
                int functionIndex = functions[i].Index;
                int numOfItemsToDelete;

                double functionResult = functions[i].Execute(items);

                if (functions[i] is IFunctionBase)
                {
                    numOfItemsToDelete = 2;
                    items[functions[i].Index - 1] = functionResult;
                    items.RemoveRange(functionIndex, 2);
                }
                else
                {
                    numOfItemsToDelete = 1;
                    items[functions[i].Index] = functionResult;
                    items.RemoveRange(functionIndex + 1, 1);
                }

                for (int j = functionIndex; j < items.Count; j++)
                {
                    object item = items[j];
                    if (item is ExecutableEquationItem)
                    {
                        ((ExecutableEquationItem)item).Index -= numOfItemsToDelete;
                    }
                }
            }

            return items;
        }
        private static List<object> ExecuteOperations(List<object> FunctionsExecutedItems)
        {
            List<object> items = new List<object>();
            items.AddRange(FunctionsExecutedItems);

            List<IOperation> sortedOperations = GetTFromList<IOperation>(items);
            sortedOperations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority()));

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                int operationIndex = sortedOperations[i].Index;
                IOperation operationToExecute = (IOperation)items[operationIndex];

                double operationResult = operationToExecute.Execute(items);

                for (int j = operationIndex + 2; j < items.Count; j++)
                {
                    if (items[j] is IOperation)
                    {
                        ((IOperation)items[j]).Index -= 2;
                    }
                }

                items[operationIndex - 1] = operationResult;
                items.RemoveRange(operationIndex, 2);
            }

            return items;
        }

        private static List<T> GetTFromList<T>(IEnumerable<object> items)
        {
            var toReturn = new List<T>(items.Select(i => i).OfType<T>());
            return toReturn;
        }
    }
}
