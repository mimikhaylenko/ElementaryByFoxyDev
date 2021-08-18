using CominucationWithConsole;
using HappyTicket.Model;
using HappyTicket.ViewModel;
using System;
using System.Collections.Generic;

namespace HappyTicket
{
    class Program
    {    
        static void Main(string[] args)
        {
            TicketController.StartProgram(args);
            ConsoleManager.CloseProgram();
        }
    }
}