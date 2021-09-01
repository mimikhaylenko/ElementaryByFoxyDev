
namespace LuckyTicket.Model
{
    public class Ticket
    {
        public string Number { get; private set; }
        public static int TicketNumbersLength { get; set; } = 6;

        public Ticket(string number)
        {
            Number = number;
        }
    }
}
