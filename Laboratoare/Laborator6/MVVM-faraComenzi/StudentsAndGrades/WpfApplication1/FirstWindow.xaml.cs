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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            //int nr = lbStudenti.SelectedItems.Count;
            //int i = 0;
            //while (i < nr)
            //{
            //    (this.DataContext as Students).StudentList.Remove(lbStudenti.SelectedItems[0] as Student);
            //    i++;
            //}
            (this.DataContext as Students).StudentList.Remove(lbStudenti.SelectedItem as Student);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Students).StudentList.Add(new Student());
        }

        private void btnNote_Click(object sender, RoutedEventArgs e)
        {
            MainWindow wind = new MainWindow(lbStudenti.SelectedItem as Student);
            wind.Show();
        }
    }
}
