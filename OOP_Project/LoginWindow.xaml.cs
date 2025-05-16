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
using OOP_Project.DTO;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            AppData.Users = JsonStorage.LoadUsers();
            AppData.Schedules = JsonStorage.LoadSchedules();

        }

        private void OpenRegisterWindow(object sender, MouseButtonEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Visibility = Visibility.Hidden;

            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();

            if (login == "admin" && password == "password")
            {
                AppData.CurrentUser = AppData.AdminUser;

                var mainMenu = new MainMenuWindow();
                mainMenu.Show();
                this.Close();
                return;
            }

            var user = AppData.Users.FirstOrDefault(u => u.Login == login);

            if (user != null && user.Password == password)
            {
                AppData.CurrentUser = user;

                var mainMenu = new MainMenuWindow();
                mainMenu.Show();
                this.Close();
            }
            else
            {
                ErrorText.Visibility = Visibility.Visible;
            }
        }


        private void GuestLogin_Click(object sender, MouseButtonEventArgs e)
        {
            AppData.CurrentUser = null;
            var mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            this.Close();
        }
    }
}
