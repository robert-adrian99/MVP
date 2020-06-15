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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student student;
        public MainWindow(Student student)
        {
            InitializeComponent();
            this.student = student;
            this.DataContext = student;
        }

        private void btnNota_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as Student).ListaNote.Add(new Nota());
        }

        private void btnStud_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DATE STUDENT:\r\n" + student);
        }

        private void btnSterge_Click(object sender, RoutedEventArgs e)
        {
            int nr = lbNote.SelectedItems.Count;
            int i = 0;
            while (i < nr)
            {
                (this.DataContext as Student).ListaNote.Remove(lbNote.SelectedItems[0] as Nota);
                i++;
            }
        }
    }
}
