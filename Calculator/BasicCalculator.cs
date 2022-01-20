using System;
using System.Collections.Generic;
using ExtensionMethods;


namespace Calculator
{
    public class BasicCalculator : ICalculator
    {
        private readonly List<char> _allowedChars = new List<char>();

        public BasicCalculator(IEnumerable<char> allowedNums, IEnumerable<char> allowedSigns)
        {
            _allowedChars.AddRange(allowedNums);
            _allowedChars.AddRange(allowedSigns);
        }
        public string Calculate(string inputString)
        {
            if (_allowedChars == null || _allowedChars.Count == 0)
            {
                throw new ArgumentOutOfRangeException("_allowedChars");
            }

            inputString = inputString.RemoveOtherThanAllowedChars(_allowedChars);

            return ComputeResult(inputString);
        }

        private string ComputeResult(string InputTrimmedString)
        {
            String numToAdd = string.Empty;

            int result = 0;

            for (int i = 0; i < InputTrimmedString.Length; i++)
            {
                if (InputTrimmedString[i] != '+')
                {
                    string charToString = InputTrimmedString[i].ToString();
                    numToAdd += charToString;

                    if (i == InputTrimmedString.Length - 1)
                    {
                        result += int.Parse(numToAdd);
                    }
                }
                else
                {
                    try
                    {
                        result += int.Parse(numToAdd);
                    }
                    catch (FormatException ex)
                    {
                        //ShowPopUpError(ex);
                    }

                    numToAdd = "";
                }
            }

            return Convert.ToString(result);
        }
    }
}
