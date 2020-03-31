using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Colour
    {
        private byte red, green, blue;

        public static readonly Colour Red;
        public static readonly Colour Green;
        public static readonly Colour Blue;

        static Colour()
        {
            Red = new Colour(255, 0, 0);
            Green = new Colour(0, 255, 0);
            Blue = new Colour(0, 0, 255);
        }

        public Colour(byte r, byte g, byte b)
        {
            red = r;
            green = g;
            blue = b;
        }
    }
}
