using System.Collections.Generic;
using System.Linq;
using System;
using ExtensionMethods;

namespace Calculator
{
    public static class CalculationHelper
    {
        public static Equation GetEquationFromString(string inputString)
        {
            if (inputString is null)
            {
                throw new ArgumentNullException();
            }

            List<object> items = new List<object>();
            string stringToCheck = string.Empty;
            bool isNumber = false;
            double number = double.MinValue;

            for (int i = 0; i < inputString.Length; i++)
            {
                stringToCheck += inputString[i];

                isNumber = number.TryParseIfFailsOutsUnchangedNum(stringToCheck, out number, Settings.DecimalSeparator);

                if (isNumber)
                {
                    if (i < inputString.Length - 1)
                    {
                        continue;
                    }

                    try
                    {
                        items.Add(number);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException();
                    }

                    break;
                }

                if (number != double.MinValue)
                {
                    items.Add(number);
                    number = double.MinValue;
                    stringToCheck = inputString[i].ToString();
                }

                var matchedFunctions = ExecutableItems.Get().Where(f => f.GetStringRepresentation() == stringToCheck);

                if (matchedFunctions.Count() == 1)
                {
                    var item = (IFunction)matchedFunctions.First();
                    EquationItem itemToAdd = null;
                    //TODO empty space handling

                    if (item.Type == FunctionType.Function)
                    {
                        itemToAdd = (EquationItem)item.NewInstance();
                    }
                    else if (item.Type == FunctionType.Operation)
                    {
                        AddToItemsIfIsLastChar(i);

                        /*if (items.Count == 0)
                        {
                            continue;
                        }*/

                        itemToAdd = (EquationItem)item.NewInstance();
                    }
                    else if (item.Type == FunctionType.Constant)
                    {
                        itemToAdd = (EquationItem)item.NewInstance();
                    }

                    itemToAdd.Index = items.Count;
                    items.Add(itemToAdd);
                    stringToCheck = string.Empty;
                    continue;
                }

                if (stringToCheck == "(")
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
            IEquation subEquation = GetEquationFromString(subString);
            return (subEquation, endIndex);
        }
    }
}
