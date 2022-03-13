using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using ExtensionMethods;

namespace Calculator
{
    public static class EquationHelper
    {
        public static double GetNumber(int startIndex, int indexShift, IEquation equation)
        {
            int numIndex = startIndex + indexShift;

            if (equation == null)
            {
                throw new ArgumentNullException("Equation is null!"); //TODO popup error
            }

            if (equation.Items.Count <= numIndex)
            {
                throw new IndexOutOfRangeException("Index is out of range!");//TODO popup error
            }

            var num = equation.Items[numIndex];

            if (num is IEquation)
            {
                return ((IEquation)num).Calculate();
            }
            else if (num is double)
            {
                return (double)num;
            }

            throw new FormatException("Expected equation or double but received something else!"); //TODO popup error
        }

        public static Equation ExtractItems(string inputString)
        {
            List<object> items = new List<object>();
            string stringToCheck = string.Empty;
            bool isNumber = false;
            double number = double.MinValue;

            for (int i = 0; i < inputString.Length; i++)
            {
                stringToCheck += inputString[i];

                isNumber = number.TryParseIfFailsOutsUnchangedNum(stringToCheck, out number);

                if (isNumber)
                {
                    if (i < inputString.Length - 1)
                    {
                        continue;
                    }

                    try
                    {
                        items.Add(double.Parse(stringToCheck));
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException(); //TODO exception handling
                    }

                    break;
                }

                if (number != double.MinValue)
                {
                    items.Add(number);
                    number = double.MinValue;
                    stringToCheck = inputString[i].ToString();
                }

                var matchedFunctions = ExecutableFunctions.AllExeEqItems.Where(f => f.GetStringRepresentation() == stringToCheck);

                if (matchedFunctions.Count() == 1)
                {
                    var item = matchedFunctions.First();
                    ExecutableEquationItem itemToAdd = null;
                    //TODO zrusit IOperation a operacie budu tiež iba IFunction - je to vlastne dobrý nápad? :D
                    //TODO empty space handling
                    if (item is IFunction)
                    {
                        itemToAdd = (ExecutableEquationItem)((IFunction)item).NewInstance();
                    }
                    else if (item is IOperation)
                    {
                        AddToItemsIfIsLastChar(i);

                        if (items.Count == 0)
                        {
                            continue;
                        }

                        itemToAdd = (ExecutableEquationItem)((IOperation)item).NewInstance();
                    }

                    itemToAdd.Index = items.Count;
                    items.Add(itemToAdd);
                    stringToCheck = string.Empty;
                    continue;
                }

                if (stringToCheck == "(") //TODO urobiť "(" podla systemoveho nastavenia. Je vobec niečo také? Nie sú zátvorky univerzálne všade?
                {
                    string subString = inputString.Substring(i);
                    var subEquationAndNewIndex = ConvertParenthesisToEquation(subString);
                    items.Add(subEquationAndNewIndex.subEquation);
                    i += subEquationAndNewIndex.subEquationLength;

                    stringToCheck = string.Empty;
                }

                AddToItemsIfIsLastChar(i);
            }

            return new Equation(items);

            void AddToItemsIfIsLastChar(int i)
            {
                if (i == inputString.Length - 1 && stringToCheck != string.Empty)
                {
                    items.Add(stringToCheck);
                }
            }
        }

        private static (IEquation subEquation, int subEquationLength) ConvertParenthesisToEquation(string inputStaringWithLeftParenthesis)
        {
            int leftParenthesisCount = 0;
            int rightParenthesisCount = 0;
            int endIndex = -1;

            for (int i = 0; i < inputStaringWithLeftParenthesis.Length; i++)
            {
                if (inputStaringWithLeftParenthesis[i] == '(')
                {
                    leftParenthesisCount += 1;
                }
                else if (inputStaringWithLeftParenthesis[i] == ')')
                {
                    rightParenthesisCount += 1;
                }

                if (leftParenthesisCount == rightParenthesisCount)
                {
                    endIndex = i;
                    break;
                }
            }

            string subString = inputStaringWithLeftParenthesis.Substring(1, endIndex - 1);
            IEquation subEquation = ExtractItems(subString);
            return (subEquation, endIndex);
        }
    }
}
