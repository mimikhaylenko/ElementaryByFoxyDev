﻿using CominucationWithConsole;
using System;
using System.Collections.Generic;

namespace Fibonacci
{
   public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to \"Fibonacci Numbers\"");
            FibonacciController.Start(args);
        }
    }
}
    