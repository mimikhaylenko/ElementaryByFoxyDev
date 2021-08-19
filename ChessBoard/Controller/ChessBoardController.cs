using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard.Controller
{
   static class ChessBoardController
    {
        public static void ShowBoard(ChessBoard board)
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

        public static ChessBoard CreateChessBoard(uint width, uint height)
        {
            ChessBoard chessBoard = new ChessBoard(width, height);
            return chessBoard;
        }
    }
}
