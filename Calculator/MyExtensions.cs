using System.Collections.Generic;

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
    }
}
