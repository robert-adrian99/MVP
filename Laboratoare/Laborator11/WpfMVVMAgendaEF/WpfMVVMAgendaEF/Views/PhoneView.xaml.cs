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
using System.Windows.Shapes;
using WpfMVVMAgendaEF.ViewModels;

namespace WpfMVVMAgendaEF.Views
{
    /// <summary>
    /// Interaction logic for PhoneView.xaml
    /// </summary>
    public partial class PhoneView : Window
    {
        public PhoneView()
        {
            InitializeComponent();
        }

        private void comboPers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PhoneVM phoneVM = DataContext as PhoneVM;
            phoneVM.ChangePhonesList(int.Parse((sender as ComboBox).SelectedValue.ToString()));
        }
    }
}
