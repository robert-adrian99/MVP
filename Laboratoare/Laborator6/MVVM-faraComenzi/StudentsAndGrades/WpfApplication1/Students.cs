using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Students
    {
        public ObservableCollection<Student> StudentList { get; set; }

        public Students()
        {
            StudentList = new ObservableCollection<Student>();
            StudentList.Add(new Student() { Nume = "Popescu", Prenume = "Ion" });
            StudentList.Add(new Student() { Nume = "Ionescu", Prenume = "Ana" });
        }
    }
}
