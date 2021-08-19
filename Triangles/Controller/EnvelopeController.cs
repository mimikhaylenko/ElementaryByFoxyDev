using CominucationWithConsole;
using Envelopes.Model;
using Envelopes.Service;
using System;
using System.Collections.Generic;

namespace Envelopes.Controller
{
    static class EnvelopeController
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
                        envelopes.Add(CreateEnvelope());
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
                    bool envelopeCanFit = EnvelopeService.EnvelopeCanFit(envelopes[0], envelopes[1]);
                    var comparisonResult = envelopeCanFit ? "You can do it!!!" : "Sorry, buddy. Maybe next time";
                    Console.WriteLine(comparisonResult);
                }
                Console.WriteLine("If you want to continue press y/yes");
                answer = Console.ReadLine().ToLower();
            } while (answer.Equals("y") || answer.Equals("yes"));
        }

        private static Envelope CreateEnvelope()
        {
            Console.WriteLine("Input sides of an envelope");
            string inputLine = Console.ReadLine();
            string[] args = inputLine.Split(" ");
            try
            {               
                var sides = ConsoleManager.ArgsToList<double>(args);
                if (!sides.TrueForAll(side => side > 0))
                {
                    throw new Exception("A side was 0");
                }
                return new Envelope(sides[0], sides[1]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
