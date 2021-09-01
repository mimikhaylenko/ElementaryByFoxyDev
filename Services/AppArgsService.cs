using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Services
{
    public static class AppArgsService
    {
        private static List<T> ParseToList<T>(List<string> parameterNames, IUserInteracting source)
        {
            int parametersCount = parameterNames.Count;
            List<T> inputedParameters = new List<T>(parametersCount);
            for (int i = 0; i < parametersCount; i++)
            {
                var name = parameterNames[i];
                try
                {
                    T newParameter = source.ReadParameter<T>(name);
                    inputedParameters.Add(newParameter);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }
            return inputedParameters;
        }

        public static List<T> ArgsToList<T>(string[] args)
        {
            T inputedParameter;
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            List<T> inputedParameters = new List<T>();
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    inputedParameter = (T)converter.ConvertFromString(args[i]);
                    inputedParameters.Add(inputedParameter);
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException($"Value {args[i]} is not valid");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return inputedParameters;
        }

        public static List<T> GetParameters<T>(this IUserInteracting source, string[] args, int numberOfParameters, List<string> parametersNames = null)
        {
            List<T> inputedParameters;
            if (args.Length == numberOfParameters)
            {
                try
                {
                    return ArgsToList<T>(args);
                }
                catch (InvalidCastException ex)
                {
                    throw new OperationCanceledException("Not all parameters were inputed", ex);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (parametersNames is null)
            {
                throw new Exception("Parameters Names can't be null");
            }
            inputedParameters = ParseToList<T>(parametersNames, source);
            return inputedParameters;
        }

        public static bool TryInitParameters<T>(this IUserInteracting source, string[] args, List<string> parametersNames, out List<T> parameters)
        {
            try
            {
                parameters = source.GetParameters<T>(args, parametersNames.Count, parametersNames);
                return true;
            }
            catch
            {
                parameters = null;
            }
            return false;
        }
    }
}
