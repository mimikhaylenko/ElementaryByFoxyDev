using CominucationWithConsole;
using LuckyTicket.ViewModel;
using System;

namespace LuckyTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to LuckyTicket check");
            TicketController.Start(args);
        }
    }
}