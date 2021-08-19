using LuckyTicket.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyTicket.Services
{
   public static class TicketsService
    {
        public static bool IsEveryTicketNumberHasEnoughSymbols(string[] ticketArray, int ticketLenght)
        {
            for (int i = 0; i < ticketArray.Length; i++)
            {
                if (ticketArray[i].Length != ticketLenght)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<Ticket> InitTickets(List<uint> inputedParameters)
        {
            var tickets = new List<Ticket>();
            if (inputedParameters?.Count == 2)
            {
                uint firstTicketNumber = inputedParameters[0];
                uint lastTicketNumber = inputedParameters[1];
                if (lastTicketNumber > firstTicketNumber && (lastTicketNumber - firstTicketNumber) / 10000000 > 0)
                {
                    bool continueProcess;
                    Console.WriteLine("Amount of tickets is too big. Are you sure you want to continue? Press 'y' for continue and any other key to escape\n");
                    continueProcess = Console.Read() == 'y';
                    if (!continueProcess)
                    {
                        Console.WriteLine("Tickets were not created");                  
                    }
                }
                try
                {
                    tickets = GenerateTickets(firstTicketNumber, lastTicketNumber);
                    if (tickets.Count > 0)
                    {
                        Console.WriteLine("Tickets were created successful");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error! Tickets were not created {ex.Message}");
                }
            }
            return tickets;
        }
        public static uint GetCountOfHappyTickets(this List<Ticket> tickets, bool comlicatedCheck = false)
        {
            MulticastDelegate CkeckNumberHappyDelegate;
            uint countOfHappyTickets = 0;
            uint ticketNumber;
            bool isTicketHappy;
            if (comlicatedCheck)
            {
                CkeckNumberHappyDelegate = new Func<uint, uint, bool>(HappyNumberService.IsNumberHappyInСomplicatedWay);
            }
            else
            {
                CkeckNumberHappyDelegate = new Func<uint, uint, bool>(HappyNumberService.IsNumberHappyInSimpleWay);
            }
            tickets.ForEach(ticket =>
            {
                if (uint.TryParse(ticket.Number, out ticketNumber))
                {
                    isTicketHappy = (bool)CkeckNumberHappyDelegate.DynamicInvoke(ticketNumber, 6u);
                    if (isTicketHappy)
                    {
                        countOfHappyTickets++;
                    }
                }
            });
            return countOfHappyTickets;
        }

        public static string GetInfoAboutTickets(List<Ticket> tickets)
        {
            StringBuilder infoAboutTickets = new StringBuilder();
            var countByEasyCheck = GetCountOfHappyTickets(tickets);
            var countByComplicatedCheck = GetCountOfHappyTickets(tickets, true);
            StringBuilder infoAbboutWinMethod = countByEasyCheck > countByComplicatedCheck ?
                new StringBuilder("The Easy Check has won") : countByEasyCheck < countByComplicatedCheck ?
                new StringBuilder("The Complicated Check has won") : new StringBuilder("No winners");
            if (tickets.Count == 0)
            {
                return "The list doesn't have any ticket";
            }
            infoAboutTickets.Append("\nTotal happy tickets (easy check): ");
            infoAboutTickets.Append(countByEasyCheck);
            infoAboutTickets.Append("\nTotal happy tickets (complicated check): ");
            infoAboutTickets.Append(countByComplicatedCheck);
            infoAboutTickets.Append($"\n{infoAbboutWinMethod}");
            return infoAboutTickets.ToString();
        }

        public static List<Ticket> GenerateTickets(uint startNumber, uint endNumber)
        {
            List<Ticket> generatedThickets = new List<Ticket>();
            string newTicketNumber;
            uint newTicketNumberLength;
            for (uint i = startNumber; i <= endNumber; i++)
            {
                newTicketNumberLength = IntegerNumberService.Length(i);
                if (newTicketNumberLength < Ticket.TicketNumbersLength)
                {
                    newTicketNumber = i.ToString().PadLeft(Ticket.TicketNumbersLength, '0');
                }
                else newTicketNumber = i.ToString();
                try
                {
                    generatedThickets.Add(new Ticket(newTicketNumber));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return generatedThickets;
        }
    }
}
