using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    class PhoneVM : BasePropertyChanged
    {
        PersonBLL persBLL = new PersonBLL();
        PhoneBLL phoneBLL = new PhoneBLL();
        public PhoneVM()
        {
            PersonsList = persBLL.GetAllPersons();
        }

        #region Data Members

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        private ObservableCollection<Person> personsList;
        public ObservableCollection<Person> PersonsList
        {
            get
            {
                return personsList;
            }
            set
            {
                personsList = value;
                NotifyPropertyChanged("PersonsList");
            }
        }

        public ObservableCollection<Phone> PhonesList
        {
            get
            {
                return phoneBLL.PhonesList;
            }
            set
            {
                phoneBLL.PhonesList = value;
                NotifyPropertyChanged("PhonesList");
            }
        }

        #endregion

        #region ICommand Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Phone>(phoneBLL.AddPhone);
                }
                return addCommand;
            }
            set
            {
                addCommand = value;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Phone>(phoneBLL.ModifyPhone);
                }
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Phone>(phoneBLL.DeletePhone);
                }
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
            }
        }

        private ICommand changePersonCommand;
        public ICommand ChangePersonCommand
        {
            get
            {
                if (changePersonCommand == null)
                {
                    changePersonCommand = new RelayCommand<Person>(phoneBLL.GetPhonesForPerson);
                }
                return changePersonCommand;
            }
            set
            {
                changePersonCommand = value;
            }
        }

        #endregion
    }
}
