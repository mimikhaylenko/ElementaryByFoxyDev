using CominucationWithConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace NumericalSequence.Controller
{
    public static class NumericalSequenceController
    {
        public static void Start()
        {
            double minSquare = ConsoleManager.ReadParameter<double>("minimal square");
            if (minSquare < 0)
            {
                Console.WriteLine("Error! The square can't be less than 0");
                return;
            }
            uint countOfNumbers = ConsoleManager.ReadParameter<uint>("count of numbers");
            var sequence = GetSequence(minSquare, countOfNumbers);
            sequence.ForEach(num => Console.Write($"{num}, "));
        }

        public static List<uint> GetSequence(double minSquare, uint countOfNumbers)
        {
            var sequence = new List<uint>();
            int sequenceNumber;
            for (int i = 0; sequence.Count < countOfNumbers; i++)
            {
                sequenceNumber = i * i;
                if (sequenceNumber >= minSquare)
                {
                    sequence.Add((uint)i);
                }
            }
            return sequence;
        }
    }
}
