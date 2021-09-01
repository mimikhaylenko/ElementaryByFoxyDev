using ComunicationWithConsole;
using NUnit.Framework;
using Services;
using System.Collections.Generic;

namespace AppArgsService.Tests
{
    public class AppArgsServiceTests
    {
        [Test]
        [TestCase("as", "2", ExpectedResult = false)]
        [TestCase("5", "hj", ExpectedResult = false)]
        [TestCase("-5", "5", ExpectedResult = false)]
        [TestCase("5", "-5", ExpectedResult = false)]
        [TestCase("15", "0.5", ExpectedResult = false)]
        [TestCase("40", "40", ExpectedResult = true)]
        public bool TryInitParameters_WidthIsWord_ReturnFalse(string width, string height)
        {
            IUserInteracting userInteracting = new ConsoleManager();
            List<string> parametersNames = new List<string>() { "width", "height" };
            return userInteracting.TryInitParameters(new string[] { width, height}, parametersNames, out List<uint> parameters);
        }
    }
}