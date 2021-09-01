using ComunicationWithConsole;
using LuckyTicket.Services;
using LuckyTicket.ViewModel;
using Services;
using System;

namespace LuckyTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to LuckyTicket check");
        
            IUserInteracting consoleManager = new ConsoleManager();
            try 
            {
                TicketController ticketController = TicketController.Instance;
                ticketController.SetParameters(args, consoleManager);
                Console.WriteLine(ticketController.Start(args, consoleManager));

            }
            catch
            {
                Console.WriteLine("Parameters are not valid. Do you want to continue? (Press y or n)");
            }
        }
    }
}