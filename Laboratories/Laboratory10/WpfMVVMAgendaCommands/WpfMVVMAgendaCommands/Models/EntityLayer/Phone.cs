using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVMAgendaCommands.Models
{
    class Phone : BasePropertyChanged
    {
        private int? phoneID;
        public int? PhoneID
        {
            get
            {
                return phoneID;
            }
            set
            {
                phoneID = value;
                NotifyPropertyChanged("PhoneID");
            }
        }

        private int? personID;
        public int? PersonID
        {
            get
            {
                return personID;
            }
            set
            {
                personID = value;
                NotifyPropertyChanged("PersonID");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
    }
}
