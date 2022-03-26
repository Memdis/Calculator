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
            var constsExecutedItems = ExecuteConstants(Items);
            var constsFuncsExecutedItems = ExecuteFunctions(constsExecutedItems);
            var constsFuncsOpersExecutedItems = ExecuteOperations(constsFuncsExecutedItems);

            return GetEquationResult(constsFuncsOpersExecutedItems);
        }

        private static double GetEquationResult(List<object> EqItemsAfterConstsFuncsOpersAreExecuted)
        {
            if (EqItemsAfterConstsFuncsOpersAreExecuted.Count <= 0)
            {
                return 0;
            }

            if (EqItemsAfterConstsFuncsOpersAreExecuted.Count > 1)
            {
                throw new FormatException("Wrong input format!");
            }

            try
            {
                if (EqItemsAfterConstsFuncsOpersAreExecuted[0] is IEquation)
                {
                    var equation = (IEquation)EqItemsAfterConstsFuncsOpersAreExecuted[0];
                    return Convert.ToDouble(equation.Calculate());
                }

                return Convert.ToDouble(EqItemsAfterConstsFuncsOpersAreExecuted[0]);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input format!");
            }
        }

        private static List<object> ExecuteConstants(List<object> EqItems)
        {
            List<object> items = new List<object>();
            items.AddRange(EqItems);

            List<IFunction> constants = GetFunctionTypeFromList(items, FunctionType.Constant);

            for (int i = 0; i < constants.Count; i++)
            {
                int constIndex = constants[i].Index;
                IFunction constToExecute = (IFunction)items[constIndex];

                items[constIndex] = constToExecute.Execute(items);
            }

            return items;
        }

        private static List<object> ExecuteFunctions(List<object> EqItemsAfterConstsAreExecuted)
        {
            List<object> items = new List<object>();
            items.AddRange(EqItemsAfterConstsAreExecuted);

            List<IFunction> functions = GetFunctionTypeFromList(items, FunctionType.Function);

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
                    if (item is EquationItem)
                    {
                        ((EquationItem)item).Index -= numOfItemsToDelete;
                    }
                }
            }

            return items;
        }
        private static List<object> ExecuteOperations(List<object> EqItemsAfterConstsAndFuncsAreExecuted)
        {
            List<object> items = new List<object>();
            items.AddRange(EqItemsAfterConstsAndFuncsAreExecuted);

            List<IFunction> sortedOperations = GetFunctionTypeFromList(items, FunctionType.Operation);
            sortedOperations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority()));

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                int operationIndex = sortedOperations[i].Index;
                int operationRange = operationIndex == 0 ? 1 : 2;
                IFunction operationToExecute = (IFunction)items[operationIndex];

                double operationResult = operationToExecute.Execute(items);

                for (int j = operationIndex + 2; j < items.Count; j++)
                {
                    if (items[j] is IFunction)
                    {
                        ((IFunction)items[j]).Index -= operationRange;
                    }
                }

                if (operationIndex == 0)
                {
                    items[operationIndex] = operationResult;
                    items.RemoveRange(operationIndex + 1, operationRange);
                }
                else
                {
                    items[operationIndex - 1] = operationResult;
                    items.RemoveRange(operationIndex, operationRange);
                }
            }

            return items;
        }

        private static List<IFunction> GetFunctionTypeFromList(IEnumerable<object> items, FunctionType functionType)
        {
            var toReturn = new List<IFunction>(items.Select(i => i).OfType<IFunction>().Where(i => i.Type == functionType));
            return toReturn;
        }
    }
}
