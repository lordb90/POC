using System;

namespace ACM.Common
{
    public static class StringHandler
    {
        public static string InsertSpaces(this string source)
        {
            string results = string.Empty;
            if (!String.IsNullOrWhiteSpace(source))
            {
                foreach(char letter in source)
                {
                    if (char.IsUpper(letter) )
                    {
                        results = results.Trim();
                        results += " ";
                    }
                    results += letter;
                }
            }
            return results.Trim();
        }
    }
}
