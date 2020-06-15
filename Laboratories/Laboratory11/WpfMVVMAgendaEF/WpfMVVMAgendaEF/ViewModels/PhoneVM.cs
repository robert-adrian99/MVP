using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVMAgendaEF.Models;
using WpfMVVMAgendaEF.Utilities;
using WpfMVVMAgendaEF.Actions;

namespace WpfMVVMAgendaEF.ViewModels
{
    class PhoneVM :BaseVM
    {
        PhoneActions phAct;
        PersonActions pAct;

        public PhoneVM()
        {
            phAct = new PhoneActions(this);
            pAct = new PersonActions(null);
        }

        #region Data Members

        private int phoneId;
        private string phoneNumber;
        private string description;
        private int personId;
        private string message;
        private ObservableCollection<PersonVM> personsList;
        private ObservableCollection<PhoneVM> phonesList;

        public int PhoneId
        {
            get
            {
                return phoneId;
            }
            set
            {
                phoneId = value;
                OnPropertyChanged("PhoneId");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

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

        public ObservableCollection<PhoneVM> PhonesList
        {
            get
            {
                phonesList = phAct.PhonesForPerson(personId);
                return phonesList;
            }
            set
            {
                phonesList = value;
                OnPropertyChanged("PhonesList");
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
                    addCommand = new RelayCommand(phAct.AddMethod);
                }
                return addCommand;
            }
            set
            {
                addCommand = value;
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
                    updateCommand = new RelayCommand(phAct.UpdateMethod);
                }
                return updateCommand;
            }
            set
            {
                updateCommand = value;
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
                    deleteCommand = new RelayCommand(phAct.DeleteMethod);
                }
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
            }
        }

        //asta este pt SelectionChanged pe ComboBox
        public void ChangePhonesList(int id)
        {
            PersonId = id;
            PhonesList = phAct.PhonesForPerson(id);
        }

        #endregion
    }
}
