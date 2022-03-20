using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Calculator
{
    public class Equation : IEquation
    {
        public List<object> Items { get; set; }
        public int Index { get; set; }

        public Equation(List<object> items)
        {
            Items = items;
        }

        public double Calculate()
        {
            List<IFunction> functions = GetTFromList<IFunction>();
            List<IOperation> sortedOperations = GetTFromList<IOperation>();
            sortedOperations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority())); 

            ExecuteFunctions(functions);
            ExecuteOperations(sortedOperations);

            return GetEquationResult();
        }

        private double GetEquationResult()
        {
            if (Items.Count <= 0)
            {
                return 0;
            }

            if (Items.Count > 1)
            {
                throw new FormatException("Wrong input format!"); //TODO pupup window
            }

            try
            {
                if (Items[0] is IEquation)
                {
                    var equation = (IEquation)Items[0];
                    return Convert.ToDouble(equation.Calculate());
                }

                return Convert.ToDouble(Items[0]);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input format!"); //TODO pupup window
            }
        }

        private void ExecuteFunctions(List<IFunction> functions)
        {
            for (int i = 0; i < functions.Count; i++)
            {
                int functionIndex = functions[i].Index;
                int numOfItemsToDelete;

                double functionResult = functions[i].Execute(this);

                if (functions[i] is IFunctionBaseEq)
                {
                    numOfItemsToDelete = 2;
                    Items[functions[i].Index - 1] = functionResult;
                    Items.RemoveRange(functionIndex, 2);
                }
                else
                {
                    numOfItemsToDelete = 1;
                    Items[functions[i].Index] = functionResult;
                    Items.RemoveRange(functionIndex + 1, 1);
                }

                for (int j = functionIndex; j < Items.Count; j++)
                {
                    object item = Items[j];
                    if (item is ExecutableEquationItem)
                    {
                        ((ExecutableEquationItem)item).Index -= numOfItemsToDelete;
                    }
                }
            }
        }

        private void ExecuteOperations(List<IOperation> sortedOperations)
        {
            for (int i = 0; i < sortedOperations.Count; i++)
            {
                int operationIndex = sortedOperations[i].Index;
                IOperation operationToExecute = (IOperation)Items[operationIndex];
                
                double operationResult = operationToExecute.Execute(this);

                for (int j = operationIndex + 2; j < Items.Count; j++)
                {
                    if (Items[j] is IOperation)
                    {
                        ((IOperation)Items[j]).Index -= 2;
                    }
                }

                Items[operationIndex - 1] = operationResult;
                Items.RemoveRange(operationIndex, 2);
            }
        }

        private List<T> GetTFromList<T>()
        {
            var toReturn = new List<T>(Items.Select(i => i).OfType<T>());
            return toReturn;
        }
    }
}
