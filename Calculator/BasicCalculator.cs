using System;
using System.Collections.Generic;
using ExtensionMethods;


namespace Calculator
{
    public class BasicCalculator : ICalculator
    {
        private readonly IEnumerable<IOperation> _allowedOperations = new List<IOperation>();

        public BasicCalculator(IEnumerable<IOperation> allowedOperations)
        {
            _allowedOperations = allowedOperations;
        }
        public string Calculate(string inputString)
        {
            List<object> equation = ConvertStringToNumbersAndOperations(inputString);
            return CalculateResultOfEquation(equation);
        }

        private List<object> ConvertStringToNumbersAndOperations(string inputString)
        {
            string number = string.Empty;
            List<object> equation = new List<object>();

            for (int i = 0; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];

                if (Char.IsDigit(currentChar))                 //TODO implement double instead of int
                {
                    number += currentChar.ToString();

                    if (i == inputString.Length - 1)
                    {
                        AddNumToEquationAndReturnEmptyString(number, equation);
                    }
                }
                else
                {
                    if (number != string.Empty)
                    {
                        number = AddNumToEquationAndReturnEmptyString(number, equation);
                    }

                    int operationSignLength = GetOperationSignLength(inputString, i);
                    string operationSign = inputString.Substring(i, operationSignLength);

                    AddOperationToEquation(equation, operationSign);
                }
            }

            return equation;
        }

        private string CalculateResultOfEquation(List<object> equation)
        {
            List<IOperation> sortedOperations = SortOperationsByMathPriority(equation);

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                IOperation operation = sortedOperations[i];
                double operationResult = double.MaxValue;
                int operationIndex = operation.Index;

                IOperation operationToExecute = (IOperation)equation[operationIndex];

                try
                {
                    operationResult = operationToExecute.Execute(Convert.ToDouble(equation[operationIndex - 1]), Convert.ToDouble(equation[operationIndex + 1]));
                }
                catch (Exception)
                {
                    throw new FormatException("Format of input string is incorrect!"); //TODO pupup window
                }

                for (int j = operationIndex + 1; j < equation.Count; j++)
                {
                    if (equation[j] is IOperation)
                    {
                        ((IOperation)equation[j]).Index -= 2;
                    }
                }

                equation[operationIndex - 1] = operationResult;
                equation.RemoveRange(operationIndex, 2);
            }

            object equationResult = equation[0];
            return Convert.ToString(equationResult);
        }

        

        private void AddOperationToEquation(List<object> objects, string operationSign)
        {
            foreach (var operation in _allowedOperations)
            {
                if (operationSign == operation.GetStringRepresentation())
                {
                    IOperation newOperation = operation.NewOperation();
                    newOperation.Index = objects.Count;
                    objects.Add(newOperation);
                }
            }
        }

        private int GetOperationSignLength(string inputString, int startIndex)
        {
            int subStrLength = 1;

            for (int j = startIndex + 1; j < inputString.Length; j++)
            {
                if (Char.IsDigit(inputString[j]))
                {
                    subStrLength = j - startIndex;
                    break;
                }
            }

            return subStrLength;
        }

        private string AddNumToEquationAndReturnEmptyString(string num, List<object> objects)
        {
            try
            {
                objects.Add(int.Parse(num));
            }
            catch (FormatException ex)
            {
                throw; //TODO implement exception
            }

            return string.Empty;
        }

        private List<IOperation> SortOperationsByMathPriority(List<object> numsAndOperations)
        {
            List<IOperation> operations = new List<IOperation>();
            
            foreach (var obj in numsAndOperations)
            {
                if (obj is IOperation)
                {
                    operations.Add((IOperation)obj);
                }
            }
            
            operations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority()));

            return operations;
        }
    }
}
