using System;
using System.Collections.Generic;
using System.Globalization;


namespace Calculator
{
    public class BasicCalculator : ICalculator
    {
        private readonly IEnumerable<IOperation> _allowedOperations = new List<IOperation>();
        private readonly IEquation _equation;

        public BasicCalculator(IEnumerable<IOperation> allowedOperations)
        {
            _allowedOperations = allowedOperations;
        }
        public string Calculate(string inputString)
        {
            IEquation equation = new Equation(ConvertStringToItemsOfEquation(inputString));

            double result = equation.Calculate();
            return Convert.ToString(result);
        }

        private List<object> ConvertStringToItemsOfEquation(string inputString)
        {
            string number = string.Empty;
            List<object> items = new List<object>();

            for (int i = 0; i < inputString.Length; i++)
            {
                char currentChar = inputString[i];

                if (Char.IsDigit(currentChar))
                {
                    number += currentChar.ToString();

                    if (i == inputString.Length - 1)
                    {
                        AddNumToEquationAndReturnEmptyString(number, items);
                    }
                }
                else
                {
                    if (number != string.Empty)
                    {
                        if (currentChar == CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]) //TODO nastavenie desatinnej čiarky/bodky
                        {
                            number += currentChar.ToString();
                        }
                        else
                        {
                            number = AddNumToEquationAndReturnEmptyString(number, items);
                        }
                    }
                    
                    if (currentChar == '(')
                    {
                        string subString = inputString.Substring(i);
                        var subEquationAndNewIndex = ConvertParenthesisToEquation(subString);
                        items.Add(subEquationAndNewIndex.subEquation);
                        i += subEquationAndNewIndex.newI;
                    }
                    else
                    {
                        int operationSignLength = GetOperationSignLength(inputString, i);
                        string operationSign = inputString.Substring(i, operationSignLength);

                        AddOperationToEquation(items, operationSign);
                    }
                }
            }

            return items;
        }

        private (IEquation subEquation, int newI) ConvertParenthesisToEquation(string input)
        {
            int leftParenthesisCount = 0;
            int rightParenthesisCount = 0;
            int endIndex = -1;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    leftParenthesisCount += 1;
                }
                else if (input[i] == ')')
                {
                    rightParenthesisCount += 1;
                }

                if (leftParenthesisCount == rightParenthesisCount)
                {
                    endIndex = i;
                    break;
                }
            }

            string subString = input.Substring(1, endIndex - 1);
            IEquation subEquation = new Equation(ConvertStringToItemsOfEquation(subString));
            return (subEquation, endIndex);
        }
        
        private void AddOperationToEquation(List<object> items, string operationSign)
        {
            foreach (var operation in _allowedOperations)
            {
                if (operationSign == operation.GetStringRepresentation())
                {
                    IOperation newOperation = operation.NewOperation();
                    newOperation.Index = items.Count;
                    items.Add(newOperation);
                }
            }
        }

        private int GetOperationSignLength(string inputString, int startIndex)
        {
            int subStrLength = 1;

            for (int j = startIndex + 1; j < inputString.Length; j++)
            {
                char currentChar = inputString[j];
                if (Char.IsDigit(currentChar) || currentChar == '(')
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
                objects.Add(double.Parse(num));
            }
            catch (FormatException ex)
            {
                throw; //TODO implement exception
            }

            return string.Empty;
        }
    }
}
