using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class B :  A
    {
        public virtual void F()
        {
            Console.WriteLine("F() din B");
        }
    }
}
