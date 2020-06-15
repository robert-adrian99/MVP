using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Utilities;
using WpfMVVMAgendaEF.Actions;

namespace WpfMVVMAgendaEF.ViewModels
{
    class PersonVM : BaseVM
    {
        PersonActions pAct;

        public PersonVM()
        {
            pAct = new PersonActions(this);
        }

        #region Data Members

        private int personId;
        private string name;
        private string address;
        private string message;
        private ObservableCollection<PersonVM> personsList;

        public int PersonId
        {
            get
            {
                return personId;
            }
            set
            {
                personId = value;
                OnPropertyChanged("PersonId");
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }

        public ObservableCollection<PersonVM> PersonsList
        {
            get
            {
                personsList = pAct.AllPersons();
                return personsList;
            }
            set
            {
                personsList = value;
                OnPropertyChanged("PersonsList");
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
                    addCommand = new RelayCommand(pAct.AddMethod);
                }
                return addCommand;
            }
        }

        //asta este pt butonul Update
        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand(pAct.UpdateMethod);
                }
                return updateCommand;
            }
        }

        //asta este pt butonul Delete
        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(pAct.DeleteMethod);
                }
                return deleteCommand;
            }
        }

        #endregion
    }
}
