using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ulong> sequenceFibonacci = GetFibonacciNumbers(9000,1000000000000);
            var res = sequenceFibonacci.FindAll(item => item >= 9000 && item <= 1000000000000);
            res.ForEach(r => { Console.WriteLine(r); });
            Console.ReadLine();
        }
    }
}
