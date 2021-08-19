using CominucationWithConsole;
using LuckyTicket.Model;
using LuckyTicket.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyTicket.ViewModel
{
    static class TicketController
    {
        public static void Start(string[] args)
        {
            List<Ticket> tickets;
            if (!TicketsService.IsEveryTicketNumberHasEnoughSymbols(args, 6))
            {
                Console.WriteLine("Error! Parameters are not valid.");
            }
            List<uint> parameters;
            bool isParametersValid = ConsoleManager.TryInitParameters(args, new List<string>(), out parameters);
            if (isParametersValid)
            {
                tickets = TicketsService.InitTickets(parameters);
                Console.WriteLine(TicketsService.GetInfoAboutTickets(tickets));
            }
            else
            {
                Console.WriteLine("Parameters are not valid. Do you want to continue? (Press y or n)");
            }
        }     
    }
}
