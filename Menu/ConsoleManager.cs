using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CominucationWithConsole
{
    public static class ConsoleManager
    {
        public static List<T> ParseToList<T>(List<string> parameterNames)
        {
            int parametersCount = parameterNames.Count;
            List<T> inputedParameters = new List<T>(parametersCount);
            for (int i = 0; i < parametersCount; i++)
            {
                var name = parameterNames[i];
                try
                {
                    T newParameter = ReadParameter<T>(name);
                    inputedParameters.Add(newParameter);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            return inputedParameters;
        }

        public static T ReadParameter<T>(string parameterName)
        {
            T inputedParameter = default(T);
            bool inputIsValid;
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            do
            {
                Console.WriteLine($"Enter the {parameterName} or press /q for exit");
                string inputedString = Console.ReadLine();
                try
                {
                    inputedParameter = (T)converter.ConvertFromString(inputedString);
                    inputIsValid = true;
                }
                catch
                {
                    inputIsValid = false;
                }
                if (!inputIsValid)
                {
                    if (inputedString.Equals("/q"))
                    {
                        throw new OperationCanceledException("Value is null");
                    }
                    Console.WriteLine("Error! Invalid input");
                }
            } while (!inputIsValid);
            return inputedParameter;
        }

        public static List<T> ArgsToList<T>(string[] args)
        {
            T inputedParameter;
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            List<T> inputedParameters = new List<T>();
            for (int i = 0; i < args.Length; i++)
            {
                try {
                    inputedParameter = (T)converter.ConvertFromString(args[i]);
                    inputedParameters.Add(inputedParameter);
                }
                catch(InvalidCastException)
                {
                    throw new Exception($"Value {args[i]} is not valid");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return inputedParameters;
        }
        public static List<T> GetParameters<T>(string[] args, List<string> parametersNames = null)
        {
            List<T> inputedParameters;
            if (args.Length == 2)
            {
                try
                {
                    return ArgsToList<T>(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new OperationCanceledException("Not all parameters were inputed");
                }
            }
            if (parametersNames is null)
            {
                throw new OperationCanceledException("parametersNames can't be null");
            }           
            inputedParameters = ParseToList<T>(parametersNames);
            return inputedParameters;
        }
        public static bool TryInitParameters(string[] args, List<string> parametersNames, out List<uint> parameters)
        {
            try
            {
                parameters = GetParameters<uint>(args, parametersNames);
                return true;
            }
            catch (Exception ex)
            {
                parameters = null;
                Console.WriteLine($"Error. The parameters are not aligned({ex})");
            }
            return false;
        }
        public static void CloseProgram()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("Press any key to exit");
           // Console.Read();
            Console.ForegroundColor = ConsoleColor.White;
        }   
    }
}