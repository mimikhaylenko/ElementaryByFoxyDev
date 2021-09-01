using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ComunicationWithConsole
{
    public class ConsoleManager: IUserInteracting
    {
        public T ReadParameter<T>(string parameterName)
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
    }
}