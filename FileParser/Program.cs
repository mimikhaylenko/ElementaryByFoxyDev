//Файловый парсер
//Нужно написать программу, которая будет иметь два режима:
//Считать количество вхождений строки в текстовом файле. 
//Делать замену строки на другую в указанном файле
//Программа должна принимать аргументы на вход при запуске:
//< путь к файлу> <строка для подсчёта>
//<путь к файлу> <строка для поиска> <строка для замены>

using FileParser.Controller;
using System;

namespace FileParser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to \"FileParser\"");
            FileParserController.Start(args);
        }
    }
}
