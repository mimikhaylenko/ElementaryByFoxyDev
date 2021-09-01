using ComunicationWithConsole;
using Services;
using System;
using System.Collections.Generic;

namespace IntToString
{
    public static class EasyNumber
    {

        public static Dictionary<long, string> Numbers = new Dictionary<long, string>
        {
            {0,""},
            {1,"один"},
            {2,"два"},
            {3,"три" },
            {4,"четыре"},
            {5,"пять"},
            {6,"шесть"},
            {7,"семь"},
            {8,"восемь"},
            {9,"девять"},
            {10,"десять"},
            {11,"одиннадцать" },
            {12,"двенадцать" },
            {13,"тринадцать" },
            {14,"четырнадцать" },
            {15,"пятнадцать" },
            {16,"шестнадцать" },
            {17,"семнадцать" },
            {18,"восемнадцать" },
            {19,"девятнадцать" },
            {20,"двадцать" },
            {30,"тридцать" },
            {40,"сорок" },
            {50,"пятьдесят" },
            {60,"шестьдесят" },
            {70,"семьдесят" },
            {80,"восемьдесят" },
            {90,"девяносто" },
            {100,"сто" },
            {200,"двести" },
            {300,"триста" },
            {400,"четыриста" },
            {500,"пятсот" },
            {600,"шестьсот" },
            {700,"семьсот" },
            {800,"восемьсот" },
            {900,"девятьсот" },
            {1000,"одна тысяча" },
            {2000,"две тысячи" },
            {1000000,"миллион" },
            {1000000000,"миллиард" },
            {1000000000000,"биллион" },
            {1000000000000000,"триллион" }
        };
        public static string GetString(this int number)
        {
            if (Numbers.ContainsKey(number))
            {
                return Numbers[number];
            }
            if (Numbers.ContainsKey(number % 100))
            {
                return Numbers[number / 100 * 100] + " " + Numbers[number % 100];
            }
            string res = string.Empty;
            for (int i = 2; i >= 0; i--)
            {
                var numPart = (int)((int)(number / Math.Pow(10, i)) * Math.Pow(10, i) % Math.Pow(10, i + 1));
                if (Numbers.ContainsKey(numPart))
                {
                    res += Numbers[numPart];
                }
                if (i != 0 && !String.IsNullOrEmpty(res))
                {
                    res += " ";
                }
            }
            return res;
        }
    }
    class Number
    {
        public static Dictionary<int, string> NumbersClassess = new Dictionary<int, string>
        {
            { 0, ""},
            { 1, "тысяча"},
            { 2, "миллион"},
            { 3, "миллиард"},
            { 4, "биллион"},
            { 5, "триллион"},
        };
        public long Value { get; set; }
        string stringValue;
        public string StringValue
        {
            get
            {                
                if (stringValue is null)
                {
                    if(Value == 0)
                    {
                        return "ноль";
                    }
                    for (int i = Classes.Count - 1; i >= 0; i--)
                    {
                        string className = string.Empty;
                        string classValue = Classes[i].GetString();
                        if (NumbersClassess[i].Equals("тысяча"))
                        {
                            if (classValue.EndsWith('а'))
                            {
                                classValue = classValue[0..^1] + 'е';
                                className = NumbersClassess[i][0..^1] + 'и';
                            }
                            else if (classValue.EndsWith('н'))
                            {
                                classValue = classValue[0..^2] + "на";
                                className = NumbersClassess[i];
                            }
                            else if (classValue.EndsWith('е') || classValue.EndsWith('и'))
                            {
                                className = NumbersClassess[i][0..^1] + 'и';
                            }
                            else if (classValue.EndsWith('ь'))
                            {
                                className = NumbersClassess[i][0..^1];
                            }
                        }
                        else if (!NumbersClassess[i].Equals(""))
                        {
                            if (classValue.EndsWith('ь'))
                            {
                                className = NumbersClassess[i] + "ов";
                            }
                            else if (classValue.EndsWith('н'))
                            {
                                className = NumbersClassess[i];
                            }
                            else
                            {
                                className = NumbersClassess[i] + 'а';
                            }
                        }
                        if (!string.IsNullOrEmpty(classValue))
                        {
                            stringValue += classValue + " " + className + " ";
                        }
                    }
                }
                return stringValue;
            }
            set => stringValue = value;
        }
        public void InitClassess()
        {
            long value = Value;
            while (value > 0)
            {
                Classes.Add((int)(value % 1000));
                value = (long)value / 1000;
            }
        }
        public List<int> Classes;

        public Number(long value)
        {
            Classes = new List<int>();
            Value = value;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> parametersNames = new List<string>() { "number" };
            if ((new ConsoleManager()).TryInitParameters(args, parametersNames, out List<long> parameters))
            {
                Number n = new Number(parameters[0]);
                n.InitClassess();
                Console.WriteLine(n.StringValue);
            }
        }
    }
}

