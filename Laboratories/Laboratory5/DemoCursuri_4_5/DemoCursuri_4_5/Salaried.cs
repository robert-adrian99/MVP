using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Salaried : Employee
    {
        protected decimal Salary { get; set; }

        public Salaried(string n, string ss, decimal s) : base(n, ss)
        {
            Salary = s;
        }
    }
}
