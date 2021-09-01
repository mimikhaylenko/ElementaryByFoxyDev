using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChessBoard.Tests
{
    public class GetSchemaTests
    {
        [Test]
        [TestCase(7u, 2u)]
        [TestCase(8u, 4u)]
        [TestCase(0u, 0u)]
        public void GetImage_NumberOfLinesAndBoardHeightMustBeEqually(uint width, uint height)
        {
            string boardImage = new ChessBoard(width, height).GetSchema();
            int countOfNewLines = boardImage.Count(ch => ch == '\n');
            Assert.AreEqual(height, countOfNewLines);
        }
        [Test]
        [TestCase(2u, 2u, " *\n* \n")]
        [TestCase(3u, 3u, " * \n* *\n * \n")]
        [TestCase(0u, 0u, "")]
        public void GetImage_ImageOfBoardMustBeEquallyExpectedResult(uint width, uint height, string expect)
        {
            var board = new ChessBoard(width, height);
            board.SquareTypes = new [] { "*", " " };
            var actual = board.GetSchema();
            Assert.AreEqual(expect, actual);
        }
    }
}