﻿using System;
using System.Collections.Generic;

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
            var functionsAndSortedOperations = GetFunctionsAndSortedOperations();
            List<IFunction> functions = functionsAndSortedOperations.functions;
            List<IOperation> sortedOperations = functionsAndSortedOperations.sortedOperations; 

            ExecuteFunctions(functions);
            ExecutOperations(sortedOperations);

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

            if (Items[0] is IEquation  )
            {
                IEquation equation = (IEquation)Items[0];
                try
                {
                    return Convert.ToDouble(equation.Calculate());
                }
                catch (Exception)
                {
                    throw new FormatException("Wrong input format!"); //TODO pupup window
                }
            }

            try
            {
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

        private void ExecutOperations(List<IOperation> sortedOperations)
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

        private (List<IFunction> functions, List<IOperation> sortedOperations) GetFunctionsAndSortedOperations()
        {
            List<IFunction> functions = new List<IFunction>();
            List<IOperation> sortedOperations = new List<IOperation>();

            foreach (var item in Items)//TODO linq
            {
                if (item is IFunction)
                {
                    functions.Add((IFunction)item);
                }
                else if (item is IOperation)
                {
                    sortedOperations.Add((IOperation)item);
                }
            }

            sortedOperations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority()));

            return (functions, sortedOperations);
        }
    }
}
