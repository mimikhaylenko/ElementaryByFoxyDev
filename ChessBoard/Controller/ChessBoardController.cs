using ComunicationWithConsole;
using Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard.Controller
{
    public static class ChessBoardController
    {
        public static string GetBoardInfo(this IUserInteracting userInteracting, string[] args, int maximumConsoleWidth)
        {
            List<string> parametersNames = new List<string>() { "width", "height" };
            if (userInteracting.TryInitParameters(args, parametersNames, out List<uint> parameters))
            {
                ChessBoard board = new ChessBoard(parameters[0], parameters[1]);
                if (board.Width * 2 > maximumConsoleWidth)
                {
                    return "Error. The width is too big";
                }
            return board.GetSchema();
            }
            return "Error. Can't create schema";
        }
    }
}
