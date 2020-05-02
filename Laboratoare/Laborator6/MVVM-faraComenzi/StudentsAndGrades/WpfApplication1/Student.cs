using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Student
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public ObservableCollection<Nota> ListaNote { get; set; }

        public Student()
        {
            ListaNote = new ObservableCollection<Nota>();
        }

        public override string ToString()
        {
            string rezultat = Nume + " " + Prenume + "\r\n";
            foreach (Nota n in ListaNote)
            {
                rezultat += n;
            }
            return rezultat;
        }
    }
}
