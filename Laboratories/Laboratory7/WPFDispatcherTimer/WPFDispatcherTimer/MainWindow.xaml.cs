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
using System.Windows.Threading;

namespace WPFDispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        private int delay = 20;
        private DateTime deadline;

        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
        }

        private void StartTimer()
        {
            //se seteaza momentul in care trebuie sa se opreasca timer-ul
            //se adauga la data curenta un numar de secunde egal cu delay-ul
            //mai exact, peste 20 de secunde, trebuie sa se opreasca timer-ul
            //se pot adauga si minute, ore, etc... la data curenta
            deadline = DateTime.Now.AddSeconds(delay);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int secondsRemaining = (deadline - DateTime.Now).Seconds;
            if (secondsRemaining == 0)
            {
                dispatcherTimer.Stop();
                dispatcherTimer.IsEnabled = false;
                MessageBox.Show("Time has expired!");
                delay = 20;
            }
            else
            {
                label1.Content = secondsRemaining.ToString();
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //la fiecare pornire a timer-ului se reseteaza deadline-ul
            StartTimer();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            //de fiecare data cand oprim timer-ul vom reseta si delay-ul,
            //dar si deadline-ul, ca sa nu treaca pe negativ cand a ajuns la 
            //final si o luam de la capat
            delay = (deadline - DateTime.Now).Seconds;
            deadline = DateTime.Now.AddSeconds(delay);
        }
    }
}
