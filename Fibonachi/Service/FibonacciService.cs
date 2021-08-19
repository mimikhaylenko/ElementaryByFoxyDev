using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci.Service
{
    public static class FibonacciService
    {
        public static uint GetNextFibonacciNumber(uint prevNumber, uint currentNumber)
        {
            var nextNumber = prevNumber + currentNumber;
            return nextNumber;
        }

        static List<uint> InitNewFibonacciNumbersList(uint firstNumber = 1, uint secondNumber = 1)
        {
            return new List<uint> { firstNumber, secondNumber };
        }

        public static List<uint> GetSequenceFibonacci(uint minValue, uint maxValue)
        {
            var sequenceFibonacci = InitNewFibonacciNumbersList(1, 1);
            if (maxValue == 1)
            {
                return sequenceFibonacci;
            }
            uint nextSequenceValue = sequenceFibonacci[sequenceFibonacci.Count - 1];
            for (int i = 2; nextSequenceValue <= maxValue; i++)
            {
                if (minValue > sequenceFibonacci[i - 2] && minValue <= sequenceFibonacci[i - 1])
                {
                    sequenceFibonacci = InitNewFibonacciNumbersList(sequenceFibonacci[i - 1], sequenceFibonacci[i - 2] + sequenceFibonacci[i - 1]);
                    i = 2;
                }
                try
                {
                    nextSequenceValue = GetNextFibonacciNumber(sequenceFibonacci[i - 2], sequenceFibonacci[i - 1]);
                    if (nextSequenceValue > maxValue)
                        return sequenceFibonacci;
                    sequenceFibonacci.Add(nextSequenceValue);
                }
                catch (OutOfMemoryException)
                {
                    throw new Exception("The maximum value is too huge");
                }
            }
            return sequenceFibonacci;
        }

        public static List<uint> GetSequenceFibonacci(uint numbersLenght)
        {
            if(Math.Pow(10, numbersLenght - 1) > uint.MaxValue || Math.Pow(10, numbersLenght) - 1> uint.MaxValue)
            {
                throw new Exception("Cannot convert a Long to a UInt");
            }
            uint firstItem = (uint)Math.Pow(10, numbersLenght - 1);
            uint secondItem = (uint)Math.Pow(10, numbersLenght) - 1;
            return GetSequenceFibonacci(firstItem, secondItem);
        }
    }
}
