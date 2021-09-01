using System;
using System.Collections.Generic;

namespace IntToString
{
    public static class EasyNumber
    {

        public static Dictionary<int, string> Numbers = new Dictionary<int, string>
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
            {1000000000,"миллиард" }
        };
        public static string GetString(this int value)
        {
            return TransformIntToString(value);
        }
        private static string TransformIntToString(int number)
        {
            if (number == 0)
            {
                return "ноль";
            }
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
                    res += Numbers[numPart] + " ";
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
        };
        public int Value { get; set; }
        string stringValue;
        public string StringValue
        {
            get
            {
                if (stringValue is null)
                {
                    for (int i = Classes.Count - 1; i >= 0; i--)
                    {
                        stringValue += Classes[i].GetString() + " " + NumbersClassess[i] + " ";                        
                    }
                }
                return stringValue;
            }
            set => stringValue = value;
        }
        public void InitClassess()
        {
            int value = Value;
            while (value > 0)
            {
                Classes.Add(value % 1000);
                value = (int)value / 1000;
            }
        }
        public List<int> Classes;

        public Number(int value)
        {
            Classes = new List<int>();
            Value = value;
        }
    }

    public class Program
    {      
        public static void Main(string[] args)
        {
            for (int i = 1299; i < 1400; i++)
            {
                Number n = new Number(i);

                n.InitClassess();
                Console.WriteLine(n.StringValue);
            }
            Console.Read();
        }
    }
}

