﻿using CominucationWithConsole;
using Fibonacci.Service;
using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class FibonacciController
    {
        public static void Start(string[] args)
        {
            List<uint> sequenceFibonacci = new List<uint>();
            uint numbersLenght = 0;
            bool inputedOneNumber = args.Length == 1 && uint.TryParse(args[0], out numbersLenght);
            if (inputedOneNumber && numbersLenght < 1)
            {
                numbersLenght = ConsoleManager.ReadParameter<uint>("value");
            }
            else if (inputedOneNumber)
            {
                Console.WriteLine($"Fibonacci numbers with {numbersLenght} digits:"); 
                try
                {
                    sequenceFibonacci = FibonacciService.GetSequenceFibonacci(numbersLenght);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            else if (args.Length == 2)
            {
                List<uint> parameters = ConsoleManager.ArgsToList<uint>(args);
                var (minValue, maxValue) = (parameters[0], parameters[1]);
                Console.WriteLine($"Fibonacci numbers between {minValue} and {maxValue}:");
                sequenceFibonacci = FibonacciService.GetSequenceFibonacci(minValue, maxValue);
            }
            else
            {
                Console.WriteLine("The input text has too many parameters");
            }
            sequenceFibonacci.ForEach(r => { Console.Write(r + " "); });
            Console.ReadLine();
        }
    }
}
