using Envelopes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Envelopes.Service
{
    public static class EnvelopeService
    {
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
