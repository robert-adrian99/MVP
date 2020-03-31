using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Employee : object
    {
        public Employee(string name, string ssn)
        {
            Name = name;
            SSN = ssn;
        }

        public string Name { get; set; }
        public string SSN { get; set; }
    }
}
