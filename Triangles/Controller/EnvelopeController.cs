using Envelopes.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envelopes.Controller
{
    class EnvelopeController
    {
        public static void Start()
        {
            string answer;
            do
            {
                List<Envelope> envelopes = new List<Envelope>(2);
                while (envelopes.Count < 2)
                {
                    try
                    {
                        envelopes.Add(GetEnvelope());
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error! {ex}");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }
                if (envelopes.Count == 2)
                {
                    bool envelopeCanFit = EnvelopeCanFit(envelopes[0], envelopes[1]);
                    var comparisonResult = envelopeCanFit ? "You can do it" : "Sorry, buddy. Maybe next time";
                    Console.WriteLine(comparisonResult);
                }
                Console.WriteLine("If you want to continue press y/yes");
                answer = Console.ReadLine().ToLower();
            } while (answer.Equals("y") || answer.Equals("yes"));
        }

        public static (double, double) ParseParametersFromString(string str)
        {
            var parameters = (str.Split(" ").ToArray());
            if (parameters.Length != 2)
            {
                throw new Exception("Amount of parameters must be 2");
            }
            var parametersToDouble = new List<double>();
            for (int i = 0; i < parameters.Length; i++)
            {
                try
                {
                    var currentCultureName = System.Globalization.CultureInfo.CurrentCulture.Name;
                    if (currentCultureName.Contains("ru") || currentCultureName.Contains("ua"))
                        parametersToDouble.Add(double.Parse(parameters[i].Replace('.', ',')));
                    else
                        parametersToDouble.Add(double.Parse(parameters[i].Replace(',', '.')));
                }
                catch (Exception)
                {
                    throw new Exception("Parameters has a wrong format");
                }
            }
            return (parametersToDouble[0], parametersToDouble[1]);
        }

        private static Envelope GetEnvelope()
        {
            Console.WriteLine("Input sides of an envelope");
            try
            {
                var (a, b) = ParseParametersFromString(Console.ReadLine());
                return new Envelope(a, b);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EnvelopeCanFit(Envelope biggerEnvelope, Envelope smallerEnvelope)
        {
            bool envelopeCanFit = false;
            var (a, b) = OrderSidesByValue(biggerEnvelope.a, biggerEnvelope.b);
            var (a1, b1) = OrderSidesByValue(smallerEnvelope.a, smallerEnvelope.b);
            if (a > a1 && b > b1)
                return true;
            if (a < b1)
                return false;
            double c = Math.Sqrt(a * a + b * b);
            var x = Math.Sqrt(Math.Pow(b1 / 2, 2) + Math.Pow((c - a1) / 2, 2));
            if (x > a || x > b)
            {
                return envelopeCanFit;
            }
            envelopeCanFit = Math.Pow(b - x, 2) + Math.Pow(a - x, 2) > a1 * a1;
            return envelopeCanFit;
        }

        private static (double, double) OrderSidesByValue(double a, double b)
        {
            return a >= b ? (a, b) : (b, a);
        }
    }
}
