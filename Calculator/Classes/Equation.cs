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
                double functionResult;

                try
                {
                    functionResult = functions[i].Execute(this);
                }
                catch (Exception e)
                {
                    throw e;
                }

                Items[functions[i].Index] = functionResult;
            }
        }

        private void ExecutOperations(List<IOperation> sortedOperations)
        {
            for (int i = 0; i < sortedOperations.Count; i++)
            {
                int operationIndex = sortedOperations[i].Index;
                IOperation operationToExecute = (IOperation)Items[operationIndex];

                double leftNumber, rightNumber;

                try
                {
                    leftNumber = EquationHelper.GetNumber(operationIndex, -1, this); //GetNumberForOperation(-1, operationIndex);
                    rightNumber = EquationHelper.GetNumber(operationIndex, 1, this); //GetNumberForOperation(1, operationIndex);
                }
                catch (Exception)
                {
                    throw new FormatException("Wrong input format!"); //TODO pupup window
                }
                
                double operationResult = operationToExecute.Execute(leftNumber, rightNumber);

                for (int j = operationIndex + 1; j < Items.Count; j++)
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

            foreach (var item in Items)
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
