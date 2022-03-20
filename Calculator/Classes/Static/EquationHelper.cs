using System.Collections.Generic;
using System.Linq;
using System;
using System.Globalization;
using ExtensionMethods;

namespace Calculator
{
    public static class EquationHelper
    {
        public static string GetStringResult(IEquation eq)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberDecimalSeparator = Settings.DecimalSeparator;
            return CalculateEquation(eq).ToString(nfi);
        }

        public static double CalculateEquation(IEquation eq)
        {
            List<IFunction> functions = GetTFromList<IFunction>(eq.Items);
            List<IOperation> sortedOperations = GetTFromList<IOperation>(eq.Items);
            sortedOperations.Sort((y, x) => x.GetPriority().CompareTo(y.GetPriority()));

            ExecuteFunctions(functions, eq);
            ExecuteOperations(sortedOperations, eq);

            return GetEquationResult(eq);
        }
        public static Equation ExtractItems(string inputString)
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
                return CalculateEquation((IEquation)num);
            }
            else if (num is double)
            {
                return (double)num;
            }

            throw new FormatException("Expected equation or double but received something else!"); //TODO popup error
        }
        
        private static double GetEquationResult(IEquation eq)
        {
            if (eq.Items.Count <= 0)
            {
                return 0;
            }

            if (eq.Items.Count > 1)
            {
                throw new FormatException("Wrong input format!"); //TODO pupup window
            }

            try
            {
                if (eq.Items[0] is IEquation)
                {
                    var equation = (IEquation)eq.Items[0];
                    return Convert.ToDouble(CalculateEquation(equation));
                }

                return Convert.ToDouble(eq.Items[0]);
            }
            catch (Exception)
            {
                throw new FormatException("Wrong input format!"); //TODO pupup window
            }
        }

        private static void ExecuteFunctions(List<IFunction> functions, IEquation eq)
        {
            var items = eq.Items;

            for (int i = 0; i < functions.Count; i++)
            {
                int functionIndex = functions[i].Index;
                int numOfItemsToDelete;

                double functionResult = functions[i].Execute(eq);

                if (functions[i] is IFunctionBaseEq)
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
                    if (item is ExecutableEquationItem)
                    {
                        ((ExecutableEquationItem)item).Index -= numOfItemsToDelete;
                    }
                }
            }
        }

        private static void ExecuteOperations(List<IOperation> sortedOperations, IEquation eq)
        {
            var items = eq.Items;

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                int operationIndex = sortedOperations[i].Index;
                IOperation operationToExecute = (IOperation)items[operationIndex];

                double operationResult = operationToExecute.Execute(eq);

                for (int j = operationIndex + 2; j < items.Count; j++)
                {
                    if (items[j] is IOperation)
                    {
                        ((IOperation)items[j]).Index -= 2;
                    }
                }

                items[operationIndex - 1] = operationResult;
                items.RemoveRange(operationIndex, 2);
            }
        }

        private static List<T> GetTFromList<T>(IEnumerable<object> items)
        {
            var toReturn = new List<T>(items.Select(i => i).OfType<T>());
            return toReturn;
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
