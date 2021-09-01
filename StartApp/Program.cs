using System;
using System.Collections.Generic;

namespace StartApp
{
    class Program
    {
        static Dictionary<int, Action<string[]>> ProgramNumbers;
        static void Main(string[] args)
        {
            ProgramNumbers = new Dictionary<int, Action<string[]>>
            {
            {1, new Action<string[]>(ChessBoard.Program.Main)},
            {2, new Action<string[]>(Envelopes.Program.Main)},
            {3, new Action<string[]>(TrianglesSorting.Program.Main)},
            {4, new Action<string[]>(FileParser.Program.Main)},
            {5, new Action<string[]>(IntToString.Program.Main)},
            {6, new Action<string[]>(LuckyTicket.Program.Main)},
            {7, new Action<string[]>(NumericalSequence.Program.Main)},
            {8, new Action<string[]>(Fibonacci.Program.Main)},
            };
            string answer;
            do
            {
                string menuTxt = @"Select the program
1. Chessboard
2. Envelopes
3. Triangles Sorting
4. File Parser
5. Number to string
6. Lucky Ticket
7. Numerical Sequence
8. Fibonacci numbers
   or press \q for exit";
                Console.WriteLine(menuTxt);
                answer = Console.ReadLine();
                bool answerIsValid = int.TryParse(answer, out int programNum);
                if (!answer.Equals("\\q") && !answerIsValid || !ProgramNumbers.ContainsKey(programNum))
                {
                    Console.WriteLine("Input was incorrect. Please, try again");
                }
                else
                {
                    ProgramNumbers[programNum].Invoke(args);
                }
            } while (!answer.Equals("\\q"));
        }
    }
}