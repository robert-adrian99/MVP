using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WpfXMLSerialization.Models
{
    [Serializable]
    public class Car : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        [XmlAttribute]
        private string make;
        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
                NotifyPropertyChanged("Make");
            }
        }

        [XmlAttribute]
        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                NotifyPropertyChanged("Model");
            }
        }

        [XmlAttribute]
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }

        [XmlAttribute]
        private Owner owner;
        public Owner Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
                NotifyPropertyChanged("Owner");
            }
        }
    }
}
