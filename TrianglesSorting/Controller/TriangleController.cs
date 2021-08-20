using CominucationWithConsole;
using System;
using System.Collections.Generic;
using TrianglesSorting.Model;
using ValidationClass;

namespace TrianglesSorting.Controller
{
    public static class TriangleController
    {
        public static void Start()
        {
            List<Triangle> triangles = new List<Triangle>();
            string userAnswer = "y";
            do
            {
                Console.WriteLine("Input triangle's parameters in format name, a, b, c" +
                                                " (where a, b, c - are sides of the triangle)");
                var array = Console.ReadLine().TrimDoubleSpace().Split(" ");
                if (array.Length != 4)
                {
                    Console.WriteLine("Incorrect value");
                    continue;
                }
                if (TryCreateTriangle(array, out Triangle triangle))
                {
                    triangles.Add(triangle);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I can't add this one because sides of the triangle are not correct.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("If want to add one more, input \"y\" or \"yes\"");
                userAnswer = Console.ReadLine().ToLower();
            } while (userAnswer == "y" || userAnswer == "yes");  
            triangles.Sort();         
            OutTriangles(triangles);
        }

        private static void OutTriangles(List<Triangle> triangles)
        {          
            Console.WriteLine("============= Triangles list: ===============");
            triangles.ForEach(triangle => Console.WriteLine(triangle));
        }

        private static bool TryCreateTriangle(string[] parameters, out Triangle triangle)
        {
            int countOfSides = 3;
            string[] inputedParams = new string[countOfSides];
            Array.Copy(parameters, 1, inputedParams, 0, countOfSides);
            var sides = ConsoleManager.GetParameters<double>(inputedParams, countOfSides);
            sides.Sort();            
            if (sides[0] + sides[1] > sides[2])
            {
                var triangleName = parameters[0];
                triangle = new Triangle(triangleName, sides[0], sides[1], sides[2]);
                return true;
            }
            triangle = null;
            return false;
        }
    }
}
