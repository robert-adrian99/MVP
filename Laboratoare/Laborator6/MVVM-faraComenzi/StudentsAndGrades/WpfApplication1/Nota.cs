using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Nota
    {
        public int ValoareNota { get; set; }
        public String Materia { get; set; }

        public override string ToString()
        {
            return "Nota: " + ValoareNota + ", Materia: " + Materia + "\r\n";
        }
    }
}
