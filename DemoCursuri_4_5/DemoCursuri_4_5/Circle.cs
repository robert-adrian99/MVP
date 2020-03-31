using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Circle
    {
        public double Radius
        {
            get;
            set;
        }

        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
            set
            {
                Radius = Math.Sqrt(value / Math.PI);
            }
        }
    }
}
