using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfXMLSerialization.Models;

namespace WpfXMLSerialization.ViewModels
{
    [Serializable]
    public class MainWindowViewModel
    {
        [XmlArray]
        public ObservableCollection<Car> CarList { get; set; }
    }
}
