using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Utilities;
using WpfMVVMAgendaEF.Views;

namespace WpfMVVMAgendaEF.ViewModels
{
    class MainWindowVM
    {
        //asta este comanda pt toate menuItem-urile
        private ICommand openWindowCommand;
        public ICommand OpenWindowCommand
        {
            get
            {
                if (openWindowCommand == null)
                {
                    openWindowCommand = new RelayCommand(OpenWindow);
                }
                return openWindowCommand;
            }
        }

        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
                case "1":
                    PersonView pers = new PersonView();
                    pers.ShowDialog();
                    break;
                case "2":
                    PhoneView phone = new PhoneView();
                    phone.ShowDialog();
                    break;
                case "3":
                    PersonsWOPhonesView persWoPhone = new PersonsWOPhonesView();
                    persWoPhone.ShowDialog();
                    break;
                case "4":
                    //AnotherPersonView anotherPers = new AnotherPersonView();
                    //anotherPers.ShowDialog();
                    break; 
            }
        }
    }
}
