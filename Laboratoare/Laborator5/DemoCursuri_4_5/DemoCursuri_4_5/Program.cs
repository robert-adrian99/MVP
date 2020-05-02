using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            A[] x = { new A(), new B(), new C(), new D() };

            for(int i=0; i<x.Length; i++)
            {
                x[i].F();
            }
        }
    }
}
