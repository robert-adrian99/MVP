using MVVMExample1WithoutCommands.ViewModels;
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
using Views.MVVMExample1WithoutCommands.Models;

namespace MVVMExample1WithoutCommands.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : Window
    {
        public UsersView()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if (UserGrid.SelectedItems.Count > 0)
                MessageBox.Show((UserGrid.SelectedItem as User).FirstName);
            else
            {
                MessageBox.Show("Select a user!");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserId.Text))
            {
                int userID = Int32.Parse(txtUserId.Text);
                (this.DataContext as UserViewModel).Users.FirstOrDefault(i => i.UserId == userID)
                                                   .UserId++;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel currectContext =  this.DataContext as UserViewModel;
            int userId = currectContext.Users.Max(item => item.UserId) + 1;
            //int userId = (from i in currectContext.Users select i.UserId).Max() + 1;

            User user = new User();
            user.UserId = userId;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.City = txtCity.Text;
            user.State = txtState.Text;
            user.Country = txtCountry.Text;

            currectContext.Users.Add(user);
        }
    }
}
