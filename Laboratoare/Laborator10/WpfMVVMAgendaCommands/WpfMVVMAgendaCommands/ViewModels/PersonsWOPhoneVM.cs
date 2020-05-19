using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    class PersonsWOPhoneVM
    {
        public PersonsWOPhoneVM()
        {
            PersonBLL personBLL = new PersonBLL();
            PersonsList = personBLL.GetAllPersonsWithoutPhone();
        }
        public ObservableCollection<Person> PersonsList
        {
            get;
            set;
        }
    }
}
