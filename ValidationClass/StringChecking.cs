using System;
using System.Collections.Generic;

namespace ValidationClass
{
    public static class StringChecking
    {
        private class BracketsPair
        {
            public char Left { get; private set; }
            public char Right { get; private set; }

            public BracketsPair(char left, char right)
            {
                Left = left;
                Right = right;
            }
        }
      //  static List<BracketsPair> bracketsPairs = new List<BracketsPair>() { new BracketsPair('(', ')'), new BracketsPair('[', ']'), new BracketsPair('{', '}') }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool HasFormat(this string line, string format)
        {

            //\d{5}  \d{3,5}

            return true;
        }
        public static string TrimDoubleSpace(this string str)
        {
            var inputedString = str.Trim();
            while (inputedString.Contains("  "))
            {
                inputedString = inputedString.Replace("  ", " ");
            }
            return inputedString;
        }

        private static bool CheckFormatingLine(string line)
        {
            var stackForBrackets = new Stack<char>();
            for (int i = 0; i < line.Length; i++)
            {
                var currentLiteral = line[i];
                if (line[i].Equals('\\'))
                {
                    i++;
                    continue;
                }
            }
            return true;
        }
    }
}
