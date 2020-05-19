using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfXMLSerialization.Models;
using WpfXMLSerialization.ViewModels;

namespace WpfXMLSerialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SerializationActions actions = new SerializationActions();

        private void btnSerialize_Click(object sender, RoutedEventArgs e)
        { 
            actions.SerializeObject("test.xml", DataContext as MainWindowViewModel);
            MessageBox.Show("Serializare efectuata cu succes!");
        }
        private void btnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            DataContext = actions.DeserializeObject("test.xml");
        }
    }
}
