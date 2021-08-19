using ChessBoard.Controller;
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
                ChessBoard board = ChessBoardController.CreateChessBoard(parameters[0], parameters[1]);
                ChessBoardController.ShowBoard(board);
            }
            ConsoleManager.CloseProgram();
        } 
    }
}
