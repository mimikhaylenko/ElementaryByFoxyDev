using ComunicationWithConsole;
using NumericalSequence.Controller;
using Services;
using System;

namespace NumericalSequence
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Numerical Sequences");
            NumericalSequenceController.Start(new ConsoleManager());
        }
    }
}
