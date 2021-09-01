using ComunicationWithConsole;
using LuckyTicket.Model;
using LuckyTicket.Services;
using Services;
using System;
using System.Collections.Generic;

namespace LuckyTicket.ViewModel
{
    class TicketController
    {
        IUserInteracting userInteracting;
        static TicketController instance;
        List<uint> parameters;
        public static TicketController Instance
        {
            get
            {
                if(instance is null)
                {
                    instance = new TicketController();
                }
                return instance;
            }
        }
        public string Start(string[] args, IUserInteracting source)
        {   
            List<Ticket>  tickets = TicketsService.InitTickets(parameters);
            return TicketsService.GetInfoAboutTickets(tickets);
        }
        public void SetParameters(string[] args, IUserInteracting source)
        {
            parameters = new List<uint>();
            userInteracting = source;
            if (!TicketsService.IsEveryTicketNumberHasEnoughSymbols(args, 6))
            {
                throw new Exception ("Error! Parameters are not valid");
            }
            bool isParametersValid = userInteracting.TryInitParameters(args, new List<string>(), out parameters);
            if (!isParametersValid)
            {
                throw new Exception ( "Parameters are not valid. Do you want to continue? (Press y or n)");
            }
        }
    }
}
