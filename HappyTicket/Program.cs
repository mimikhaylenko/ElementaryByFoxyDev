using CominucationWithConsole;
using LuckyTicket.ViewModel;

namespace LuckyTicket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TicketController.StartProgram(args);
            ConsoleManager.CloseProgram();
        }
    }
}