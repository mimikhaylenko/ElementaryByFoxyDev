using ChessBoard.Controller;
using ComunicationWithConsole;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard.View
{
    public class ChessBoardView
    {
        private const int MAX_CONSOLE_WIDTH = 80;
        public static void Show(string[] args)
        {
            string boardSchema = (new ConsoleManager()).GetBoardInfo(args, GetMaximumConsoleWidth());
            Console.WriteLine(boardSchema);
        }
    private static int GetMaximumConsoleWidth()
        {
            int consoleWidth;
            try
            {
                consoleWidth = Console.BufferWidth;
            }
            catch (Exception)
            {
                consoleWidth = MAX_CONSOLE_WIDTH;
            }
            return consoleWidth;
        }
    }
}
