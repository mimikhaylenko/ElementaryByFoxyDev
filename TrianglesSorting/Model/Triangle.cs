using System;
using System.Collections.Generic;
using System.Text;

namespace TrianglesSorting.Model
{
    class Triangle:IComparable
    {
        private double perimeter;
        private double area;
        public string Name { get; private set; }
        public double a { get; private set; }
        public double b { get; private set; }
        public double c { get; private set; }
        public double Perimeter
        {
            get
            {
                if (perimeter == 0)
                {
                    perimeter = a + b + c;
                }
                return perimeter;
            }
        }
        public double Area
        {
            get
            {
                if (area == 0)
                {
                    double p = Perimeter / 2;
                    area = Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 3);
                }
                return area;
            }
        }
        public Triangle(string name, double a, double b, double c)
        {
            Name = name;
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override string ToString()
        {
            return $"[Triangle {Name}]: {Area} cm2";
        }

        public int CompareTo(object obj)
        {
            Triangle triangle = obj as Triangle;

            if (Area > triangle.Area)
            {
                return -1;
            }
            if (Area < triangle.Area)
            {
                return 1;
            }
            return 0;
        }
    }
}

