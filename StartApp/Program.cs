﻿namespace StartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci.Program.Main(new string[1] { "16" });
            Fibonacci.Program.Main(new string[2] { "3", "15000000" });

            LuckyTicket.Program.Main(new string[2] { "3", "15000000" });
        }
    }
}
