using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using ExtensionMethods;

namespace Calculator
{
    public static class EquationHelper
    {
        public static IEquation GetEquation(int startIndex, int eqIndexShift, IEquation equation)
        {
            if (equation == null)
            {
                throw new ArgumentNullException("Equation is null!"); //TODO popup error
            }

            var eq = equation.Items[startIndex + eqIndexShift];

            equation.Items.RemoveAt(startIndex + eqIndexShift);
            UpdateIndexes(startIndex + eqIndexShift, equation);

            if (eq is IEquation)
            {
                return (IEquation)eq;
            }
            else if (eq is double)
            {
                return new Equation(new List<object> { eq });
            }

            throw new ArgumentException("Expected equation but received something else!"); //TODO popup error
        }

        private static void UpdateIndexes(int indexStart, IEquation equation)
        {
            for (int i = indexStart; i < equation.Items.Count; i++)
            {
                object item = equation.Items[i];
                if (item is ExecutableEquationItem)
                {
                    ((ExecutableEquationItem)item).Index -= 1;
                }
            }
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

                    if (item is IFunction)
                    {
                        itemToAdd = (ExecutableEquationItem)((IFunction)item).NewInstance();
                    }
                    else if (item is IOperation)
                    {
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
            }

            return new Equation(items);
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

//1
//1+1
//1,1+1
//1,1+1,1
//1+sin(1)
//1,1+sin(1)
//1,1+sin(1,1)
//1,1+sin(1+1)
//1,1+sin(1,1+1,1)
//1,1+sin(1,1+1,1)*2
//1,1+sin(1,1+1,1)*2,2
//1,1+sin(1,1+1,1+(sin(1,1+1,1)))*2,2
//sin(1)
//sin(1,1)
//sin(1+1)
//sin(1,1+1)
//sin(1,1+1,1)
//sin(1,1+1,1+(sin(1,1+1,1)))
//sin(1,1+1,1)*sin(1,1+1,1)
//(2)^(2)
//(2,2)^(2,2)
//(2,2)^(2,2)*(2,2)^(2,2)
//1,1+sin(1,1+1,1+(sin(1,1+1,1)))*2,2+(2,2)^(2,2)*tan(1)
//sin-1(0,3)

