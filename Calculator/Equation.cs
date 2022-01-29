using System;
using System.Collections.Generic;


namespace Calculator
{
    public class Equation : IEquation
    {
        public List<object> Items { get; private set; }
        public int Index { get; set; }

        public Equation(List<object> items)
        {
            Items = items;
        }

        public double Calculate()
        {
            List<IOperation> sortedOperations = SortOperationsByMathPriority(Items);

            for (int i = 0; i < sortedOperations.Count; i++)
            {
                IOperation operation = sortedOperations[i];
                double operationResult = double.MaxValue;
                int operationIndex = operation.Index;

                IOperation operationToExecute = (IOperation)Items[operationIndex];

                double leftNumber = double.MinValue;
                double rightNumber = double.MinValue;

                if (Items[operationIndex - 1] is IEquation)
                {
                    IEquation leftEquation = (IEquation)Items[operationIndex - 1];
                    leftNumber = leftEquation.Calculate();
                }
                else
                {
                    try
                    {
                        leftNumber = Convert.ToDouble(Items[operationIndex - 1]);
                    }
                    catch (Exception)
                    {
                        throw new FormatException("Format of input string is incorrect!");
                    }
                }

                if (Items[operationIndex + 1] is IEquation)
                {
                    IEquation rightEquation = (IEquation)Items[operationIndex + 1];
                    rightNumber = rightEquation.Calculate();
                }
                else
                {
                    try
                    {
                        rightNumber = Convert.ToDouble(Items[operationIndex + 1]);
                    }
                    catch (Exception)
                    {
                        throw new FormatException("Format of input string is incorrect!");
                    }
                }

                operationResult = operationToExecute.Execute(leftNumber, rightNumber);

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

            if (Items[0] is IEquation)
            {
                IEquation equation = (IEquation)Items[0];
                return Convert.ToDouble(equation.Calculate());
            }

            object equationResult = Items[0];
            return Convert.ToDouble(equationResult);
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
