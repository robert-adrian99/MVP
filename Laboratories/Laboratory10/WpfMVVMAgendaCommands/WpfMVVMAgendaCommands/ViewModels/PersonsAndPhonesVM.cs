using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    class PersonsAndPhonesVM
    {
        public Dictionary<Person, ObservableCollection<Phone>> Agenda { get; set; }

        public PersonsAndPhonesVM()
        {
            PersonBLL personBLL = new PersonBLL();
            Agenda = new Dictionary<Person, ObservableCollection<Phone>>();
            foreach(Person person in personBLL.GetAllPersons())
            {
                PhoneBLL phoneBLL = new PhoneBLL();
                phoneBLL.GetPhonesForPerson(person);
                Agenda.Add(person, phoneBLL.PhonesList);
            }
           // (Agenda.Keys[0] as Person).Name
        }
    }
}
