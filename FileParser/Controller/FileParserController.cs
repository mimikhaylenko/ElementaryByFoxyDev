using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace FileParser.Controller
{
    public static class FileParserController
    {
        public static void Start(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Error! Inputed parameters are invalid");
                return;
            }
            Array.ForEach(args, ar => Console.WriteLine(ar));
            var parameters = GetParams(args);
            var filePath = parameters[0];
            if (!File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error! Can not find a file {filePath}");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (string.IsNullOrEmpty(parameters[1]))
            {
                Console.WriteLine("The search string was empty");
                return;
            }
            if (parameters.Count == 3)
            {
                if (TryReplace(filePath, parameters[1], parameters[2]))
                {
                    Console.WriteLine("The file was modified successful");
                }
                else
                {
                    Console.WriteLine("Update failed");
                }
            }
            if (parameters.Count == 2)
            {
                var text = parameters[1];
                try
                {
                Console.WriteLine($"In total there are: {CountMathesInFile(filePath, text)} \"{text}\"");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        private static List<string> GetParams(string[] args)
        {
            List<string> parameters = new List<string>() { args[0] };
            for (int i = 1; i < args.Length; i++)
            {
                    parameters.Add(args[i][1..]);
            }
            return parameters;
        }

        public static bool TryReplace(string filePath, string searchText, string replaceText)
        {
            try
            {
                ReplaceInFile(filePath, searchText, replaceText);
                return true;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        /// <summary>
        /// Replaces text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <param name="replaceText">Text to replace the search text.</param>
    
        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                throw new ArgumentException("String cannot be of zero length. (Parameter 'oldValue')");
            }
            string content;
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                content = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            content = content.Replace(searchText, replaceText);
            using StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
        }
        /// <summary>
        /// Find similar text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        static public int CountMathesInFile(string filePath, string searchText)
        {
            string content;
            int count = 0;
            try
            {
                using StreamReader reader = new StreamReader(filePath);
                content = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == searchText[0])
                {
                    string subContent = content.Substring(i, searchText.Length);
                    if (subContent.Equals(searchText))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}