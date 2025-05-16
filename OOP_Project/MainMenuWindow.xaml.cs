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

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
            bool isAdmin = AppData.CurrentUser?.GetRole() == "Admin";
            AddButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            DeleteButton.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            AdminViewToggle.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            AdminA.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            var user = AppData.CurrentUser;

            if (user != null)
            {
                UsernameText.Text = user.Login;
                TicketsButton.IsEnabled = true;
                TicketsButton.Opacity = 1.0;
            }
            else
            {
                UsernameText.Text = "Гість";
                TicketsButton.IsEnabled = false;
                TicketsButton.Opacity = 0.5;
            }

            ProfilePopup.IsOpen = true;
        }


        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            AppData.CurrentUser = null;
            new LoginWindow().Show();
            this.Close();
        }

        private void OpenTickets_Click(object sender, RoutedEventArgs e)
        {
            //var ticketsWindow = new TicketsWindow();
            //ticketsWindow.ShowDialog();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddMenu.Visibility = Visibility.Visible;
        }

        private void CloseAddMenu_Click(object sender, RoutedEventArgs e)
        {
            AddMenu.Visibility = Visibility.Collapsed;
        }

        private void AddFilm_Click(object sender, RoutedEventArgs e)
        {
            AddMenu.Visibility = Visibility.Collapsed;
        }

        private void AddScreening_Click(object sender, RoutedEventArgs e)
        {
            AddMenu.Visibility = Visibility.Collapsed;
        }


    }
}
