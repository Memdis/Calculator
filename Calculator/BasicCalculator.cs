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
            //_allowedChars.AddRange(allowedOperations);
            _allowedOperations = allowedOperations;
        }
        public string Calculate(string inputString)
        {

            //inputString = inputString.RemoveOtherThanAllowedChars(_allowedChars);

            return ComputeResult(inputString);
        }

        private string ComputeResult(string InputTrimmedString)
        {
            List<object> objects = StringToObjects(InputTrimmedString);
            List<IOperation> sortedOperations = SortedOperations(objects);

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                IOperation operation = sortedOperations[i];
                double operationResult = double.MaxValue;
                int index = operation.Index;

                IOperation opToExecute = (IOperation)objects[index];

                try
                {
                    operationResult = opToExecute.Execute(Convert.ToDouble(objects[index - 1]), Convert.ToDouble(objects[index + 1]));
                }
                catch (Exception)
                {
                    throw new FormatException("Format of input string is incorrect!"); //TODO pupup window
                }

                for (int j = index + 1; j < objects.Count; j++)
                {
                    if (objects[j] is IOperation)
                    {
                        ((IOperation)objects[j]).Index -= 2;
                    }
                }

                objects[index - 1] = operationResult;
                objects.RemoveRange(index, 2);
            }

            return Convert.ToString(objects[0]);
        }

        //why method StringToObject -> to have list of objects (numbers and math operations) from the given string
        private List<object> StringToObjects(string inputString)
        {
            string num = string.Empty;
            List<object> objects = new List<object>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (Char.IsDigit(inputString[i]))
                {
                    num += inputString[i].ToString();

                    if (i == inputString.Length - 1)
                    {
                        try
                        {
                            objects.Add(int.Parse(num));
                            num = string.Empty;
                        }
                        catch (FormatException ex)
                        {
                            throw; //TODO implement exception
                        }
                    }
                }
                else
                {
                    if (num != string.Empty)
                    {
                        try
                        {
                            objects.Add(int.Parse(num));
                            num = string.Empty;
                        }
                        catch (FormatException ex)
                        {
                            throw; //TODO implement exception
                        }
                    }

                    int subStrLength = 1;

                    for (int j = i + 1; j < inputString.Length; j++)
                    {
                        if (Char.IsDigit(inputString[j]))
                        {
                            subStrLength = j - i;
                            break;
                        }
                    }

                    string sign = inputString.Substring(i, subStrLength);

                    foreach (var operation in _allowedOperations)
                    {
                        if (sign == operation.GetRepresentation())
                        {
                            IOperation newOperation = operation.NewOperation();
                            newOperation.Index = objects.Count;
                            objects.Add(newOperation);
                        }
                    }
                }
            }

            return objects;
        }

        //why method SortedOperations -> to sort operations derived from given string by their mathematical priority
        private List<IOperation> SortedOperations(List<object> numsAndOperations)
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
