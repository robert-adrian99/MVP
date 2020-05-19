using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVMAgendaEF.Models;
using WpfMVVMAgendaEF.Actions;

namespace WpfMVVMAgendaEF.ViewModels
{
    class PersonsWoPhoneVM
    {
        public List<persoane> PersonsList
        {
            get; 
            set;
        }
        
        public PersonsWoPhoneVM()
        {
            PersonActions pAct = new PersonActions(null);
            PersonsList = pAct.PersonsWoPhone();
        }
    }
}
