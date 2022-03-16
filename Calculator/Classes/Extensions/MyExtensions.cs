using System.Collections.Generic;
using Calculator;

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
            return (System.Math.PI / 180) * num;
        }

        public static double RadToDeg(this double num)
        {
            return (180 / System.Math.PI) * num;
        }

        public static bool TryParseIfFailsOutsUnchangedNum(this double num, string toParse, out double number)
        {
            var currentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var numberFormat = (System.Globalization.NumberFormatInfo)currentCulture.NumberFormat.Clone();

            if (Settings.DecimalSeparator == DecimalSeparator.Comma)
            {
                numberFormat.NumberDecimalSeparator = ",";
            }
            else
            {
                numberFormat.NumberDecimalSeparator = ".";
            }
            
            double returnNum = num;
            var parseSuccessful = double.TryParse(toParse, System.Globalization.NumberStyles.Float, numberFormat, out returnNum);

            if (parseSuccessful)
            {
                number = returnNum;
                return parseSuccessful;
            }

            number = num;
            return parseSuccessful;
        }
    }
}
