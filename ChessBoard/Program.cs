using CominucationWithConsole;
using System;
using System.Collections.Generic;

namespace ChessBoard
{
    class Program
    {       
        static List<string> parametersNames { get; set; } = new List<string>() { "width", "height" };
        static void Main(string[] args)
        {
            if (ConsoleManager.TryInitParameters(args, parametersNames, out List<uint> parameters))
            {
                ChessBoard board = CreateChessBoard(parameters[0], parameters[1]);               
                ShowBoard(board);
            }
            ConsoleManager.CloseProgram();
        }
        private static void ShowBoard(ChessBoard board)
        {
            if (board is null)
            {
                Console.WriteLine("Error. The board was null");
                return;
            }
            int consoleWidth = 80;
            try
            {
                consoleWidth = Console.BufferWidth;
            }
            catch (Exception)
            {
            }
            if (board.Width * 2 > consoleWidth)
            {
                Console.WriteLine("Error. The width is too big");
                return;
            }
            try
            {
                board.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        private static ChessBoard CreateChessBoard(uint width, uint height)
        {
            ChessBoard chessBoard = new ChessBoard(width, height);
            return chessBoard;
        }     
    }
}
