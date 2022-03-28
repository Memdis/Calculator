using System.Collections.Generic;
using System;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static string RemoveOtherThanAllowedChars(this string str, List<char> AllowedChars)
        {
            string onlyAllowedChars = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < AllowedChars.Count; j++)
                {
                    if (str[i] == AllowedChars[j])
                    {
                        onlyAllowedChars += str[i];
                        break;
                    }
                }
            }

            return onlyAllowedChars;
        }

        public static double DegToRad(this double num)
        {
            return (Math.PI / 180) * num;
        }

        public static double RadToDeg(this double num)
        {
            return (180 / Math.PI) * num;
        }

        public static bool TryParseIfFailsOutsUnchangedNum(this double num, string toParse, out double number, string decimalSeparator)
        {
            if (decimalSeparator.Length != 1)
            {
                throw new ArgumentException("Decimal separator has incorrect format!");
            }

            var numberFormat = (System.Globalization.NumberFormatInfo)System.Globalization.CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberDecimalSeparator = decimalSeparator;

            var parseSuccessful = double.TryParse(toParse, System.Globalization.NumberStyles.Float, numberFormat, out number);

            if (parseSuccessful)
            {
                return parseSuccessful;
            }

            number = num;
            return parseSuccessful;
        }
    }
}
