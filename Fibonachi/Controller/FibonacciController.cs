using System;
using System.Collections.Generic;
using System.Text;

namespace Fibonacci.Controller
{
    class FibonacciController
    {
        public static List<ulong> GetFibonacciNumbers(long maxValue)
        {
            if (maxValue <= 0)
            {
                throw new ArgumentException("The maximum value can't be less than 1");
            }
            if (maxValue > long.MaxValue)
            {
                throw new ArgumentException("The maximum value is too huge");
            }
            var sequenceFibonacci = new List<ulong>() { 1, 1 };
            if (maxValue == 1)
            {
                return sequenceFibonacci;
            }
            ulong nextSequenceValue = sequenceFibonacci[sequenceFibonacci.Count - 1];
            for (int i = 2; nextSequenceValue <= (ulong)maxValue; i++)
            {
                try
                {
                    nextSequenceValue = sequenceFibonacci[i - 1] + sequenceFibonacci[i - 2];
                    if (nextSequenceValue < sequenceFibonacci[i - 1])
                        throw new InvalidOperationException("An item can't be casted to long");
                    sequenceFibonacci.Add(nextSequenceValue);
                }
                catch (OutOfMemoryException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return sequenceFibonacci;
        }
    }
}
