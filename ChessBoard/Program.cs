﻿using ChessBoard.Controller;
using ChessBoard.View;
using ComunicationWithConsole;
using System;

namespace ChessBoard
{
   public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Chessboard's Show");
            ChessBoardView.Show(args);
        }
    }
}
