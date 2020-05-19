using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaCommands.Exceptions;
using WpfMVVMAgendaCommands.Models;

namespace WpfMVVMAgendaCommands.ViewModels
{
    class PersonVM : BasePropertyChanged
    {
        PersonBLL persBLL = new PersonBLL();
        public PersonVM()
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

        public ObservableCollection<Person> PersonsList
        {
            get
            {
                return persBLL.PersonsList;
            }
            set
            {
                persBLL.PersonsList = value;
            }
        }
        
        #endregion

        #region Command Members

        //asta este pt butonul Add
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Person>(persBLL.AddPerson);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Person>(persBLL.ModifyPerson);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Person>(persBLL.DeletePerson);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
