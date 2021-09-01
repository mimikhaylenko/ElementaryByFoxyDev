using NUnit.Framework;
using Moq;
using System.Text.RegularExpressions;
using System.IO;
using FileParser.Controller;

namespace FileParser.Tests
{
    public class FileParserControllerTests
    {
        private string GetFileContent(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        [Test]
        [TestCase("C:\\text.txt", "I")]
        [TestCase("C:\\text.txt", " ")]

        public void CountMathesInFile_ResultAndRegexMatchesMustBeEqually(string filePath, string searchText)
        {
            string content = GetFileContent(filePath);

            int actual = FileParserController.CountMathesInFile(filePath, searchText);
            int expected = Regex.Matches(content, searchText).Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("C:\\text.txt", "I", "YOU")]
        [TestCase("C:\\text.txt", " ", "YOU")]
        public void ReplaceInFile_ResultAndRegexReplaceMustBeEqually(string filePath, string searchText, string replaceText)
        {
            string newTemporaryFileName = "newTemporaryFileForTest.txt";
            if (!File.Exists(newTemporaryFileName))
            {
                File.Copy(filePath, newTemporaryFileName);
            }            
            string content = GetFileContent(newTemporaryFileName);
            string expected = Regex.Replace(content, searchText, replaceText);
            FileParserController.ReplaceInFile(newTemporaryFileName, searchText, replaceText);
            string actual = GetFileContent(newTemporaryFileName);
            File.Delete(newTemporaryFileName);
            Assert.AreEqual(expected, actual);
        }
    }
}