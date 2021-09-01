using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class ChessBoard
    {
        public List<string> SquareTypes { get; set; }
        public uint Width { get; private set; }
        public uint Height { get; private set; }
        public uint Area { get; private set; }

        public ChessBoard(uint width, uint height)
        {
            Width = width;
            Height = height;
            Area = width * height;
            SquareTypes = new List<string>(2) { " *", "  " };
        }
        public string GetSchema()
        {         
            int charIndex = 0;
            string boardImage = string.Empty;
            for (int i = 1; i <= Area; i++)
            {
                string currentSymbol;
                currentSymbol = SquareTypes[(charIndex + i)%2];
                boardImage += currentSymbol;
                if (i % Width == 0)
                {
                  if (Width % 2 == 0)
                    { 
                        charIndex = charIndex == 1 ? 0: 1 ; 
                    }
                    boardImage += "\n";
                }
            }
            return boardImage;
        }
    }
}
