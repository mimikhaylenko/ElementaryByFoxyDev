using System;
using System.Collections.Generic;
using System.Text;

namespace CominucationWithConsole
{
    public static class ConsoleManager
    {
        public static List<uint> ParseToUint(List<string> parameterNames)
        {
            int parametersCount = parameterNames.Count;
            List<uint> inputedParameters = new List<uint>(parametersCount);
            for (int i = 0; i < parametersCount; i++)
            {
                var name = parameterNames[i];
                try
                {
                    uint newParameter = ReadParameter(name);
                    inputedParameters.Add(newParameter);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            return inputedParameters;
        }

        public static uint ReadParameter(string parameterName)
        {
            uint inputedParameter;
            bool inputIsValid;
            do
            {
                Console.WriteLine($"Enter the {parameterName} or press /q for exit");
                string inputedString = Console.ReadLine();
                inputIsValid = uint.TryParse(inputedString, out inputedParameter);
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
        public static List<uint> ArgsToUint(string[] args)
        {
            uint inputedParameter;
            List<uint> inputedParameters = new List<uint>();
            for (int i = 0; i < args.Length; i++)
            {
                if(uint.TryParse(args[i], out inputedParameter))
                {
                    inputedParameters.Add(inputedParameter);
                }
                else
                {
                    throw new Exception($"Value {args[i]} is not valid");
                }
            }
            return inputedParameters;
        }
        public static List<uint> GetParameters(string[] args, List<string> parametersNames = null)
        {
            List<uint> inputedParameters;
            if (args.Length == 2)
            {
                try
                {
                    return ConsoleManager.ArgsToUint(args);
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
            inputedParameters = ConsoleManager.ParseToUint(parametersNames);
            return inputedParameters;
        }
        public static bool TryInitParameters(string[] args, List<string> parametersNames, out List<uint> parameters)
        {
            try
            {
                parameters = GetParameters(args, parametersNames);
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
            Console.WriteLine("Press any key to exit");
            Console.Read();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static bool IsEveryStringHasEnoughSymbols(string[] ticketArray, int ticketLenght)
        {
            for (int i = 0; i < ticketArray.Length; i++)
            {
                if (ticketArray[i].Length != ticketLenght)
                {
                    return false;
                }
            }
            return true;
        }
    }
}