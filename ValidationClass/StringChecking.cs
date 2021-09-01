using System;
using System.Collections.Generic;

namespace ValidationClass
{
    public static class StringChecking
    {
        public static string TrimDoubleSpace(this string str)
        {
            var inputedString = str.Trim();
            while (inputedString.Contains("  "))
            {
                inputedString = inputedString.Replace("  ", " ");
            }
            return inputedString;
        }
    }
}
