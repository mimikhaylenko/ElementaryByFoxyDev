using System;
using System.Collections.Generic;
using System.Text;

namespace Envelopes.Model
{
   public class Envelope
    {
       public double a { get; private set; }
       public double b { get; private set; }
        public Envelope(double a, double b)
        {
            this.a = a;
            this.b = b;            
        }
    }
}
