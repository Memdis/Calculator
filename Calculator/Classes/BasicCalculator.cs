using System;
using System.Collections.Generic;
using System.Globalization;


namespace Calculator
{

    public class BasicCalculator : ICalculator
    {
        private readonly IEnumerable<IOperation> _allowedOperations = new List<IOperation>();
        private readonly IEnumerable<IFunction> _allowedFunctions = new List<IFunction>();

        public BasicCalculator(IEnumerable<IOperation> allowedOperations, IEnumerable<IFunction> aloweddFunctions)
        {
            _allowedOperations = allowedOperations;
            _allowedFunctions = aloweddFunctions;
        }
        public string Calculate(string inputString)
        {
            var equation = new Equation(ConvertStringToItemsOfEquation(inputString));

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
                            continue;
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
                        string itemStringRepresentation = GetStringOfItem(inputString, i);

                        object item = GetOperationOrFunction(itemStringRepresentation, items.Count);

                        if (item == null)
                        {
                            throw new FormatException("Incorrect format of input!"); //TODO popup window
                        }
                        
                        if (item is IFunction)
                        {
                            i += itemStringRepresentation.Length;
                            string subString = inputString.Substring(i);
                            var subEquationAndNewIndex = ConvertParenthesisToEquation(subString);
                            ((IFunction)item).Equation = subEquationAndNewIndex.subEquation;

                            if (item is IFunctionBaseEq)
                            {
                                object lastItem = items[items.Count - 1];

                                if (lastItem is IEquation)
                                {
                                    ((IFunctionBaseEq)item).BaseEquation = (IEquation)lastItem;
                                }
                                else
                                {
                                    IEquation baseEquation = new Equation(new List<object>() { (double)lastItem });
                                    ((IFunctionBaseEq)item).BaseEquation = baseEquation;
                                }

                                ((IFunctionBaseEq)item).Index -= 1;
                                items[items.Count - 1] = item;
                                i += subEquationAndNewIndex.newI;

                                continue;
                            }

                            items.Add(item);
                            i += subEquationAndNewIndex.newI;

                            continue;
                        }

                        items.Add(item);

                        continue;
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
        
        private object GetOperationOrFunction(string itemStringRepresentation, int itemsCount)
        {
            foreach (var operation in _allowedOperations)
            {
                if (itemStringRepresentation == operation.GetStringRepresentation())
                {
                    IOperation newOperation = operation.NewInstance();
                    newOperation.Index = itemsCount;
                    return (newOperation);
                }
            }

            foreach (var function in _allowedFunctions)
            {
                if (itemStringRepresentation == function.GetStringRepresentation())
                {
                    IFunction newFunction = function.NewInstance();
                    newFunction.Index = itemsCount;
                    return (newFunction);
                }
            }

            return null;
        }

        private string GetStringOfItem(string inputString, int startIndex) 
        {
            string itemString = string.Empty;

            itemString = CheckIfItemIsOperation();
            if (itemString != string.Empty)
            {
                return itemString;
            }

            itemString = GetStringUntilDigitOrParenthesis();
            return itemString;

            string CheckIfItemIsOperation()
            {
                foreach (var operation in _allowedOperations)
                {
                    if (inputString[startIndex].ToString() == operation.GetStringRepresentation())
                    {
                        return SetSubstring(startIndex, 1);
                    }
                }

                return string.Empty;
            }

            string GetStringUntilDigitOrParenthesis()
            {
                for (int j = startIndex; j < inputString.Length; j++)
                {
                    char currentChar = inputString[j];

                    if (Char.IsDigit(currentChar) || currentChar == '(')
                    {
                        return SetSubstring(j, 0);
                    }
                }

                return string.Empty;
            }

            string SetSubstring(int currentIndex, int shift)
            {
                int subStrLength = currentIndex + shift - startIndex;
                itemString = inputString.Substring(startIndex, subStrLength);
                return itemString;
            }
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
