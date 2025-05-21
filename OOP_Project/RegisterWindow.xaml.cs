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
using OOP_Project.Models;

namespace OOP_Project
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            LoginError.Visibility = Visibility.Collapsed;
            PasswordError.Visibility = Visibility.Collapsed;
            BirthDateError.Visibility = Visibility.Collapsed;
            PhoneError.Visibility = Visibility.Collapsed;

            bool hasError = false;

            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password.Trim();
            string phone = PhoneNumberTextBox.Text.Trim();
            string birth = BirthDateTextBox.Text.Trim();

            // Логін
            if (string.IsNullOrEmpty(login))
            {
                LoginError.Text = "Невірний формат логіну";
                LoginError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (login.Any(c => !((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || char.IsDigit(c) || c == '-' || c == '.' || c == '_')))
            {
                LoginError.Text = "Введено недопустимі символи";
                LoginError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (login.Length < 5)
            {
                LoginError.Text = "Логін надто короткий";
                LoginError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (login.Length > 32)
            {
                LoginError.Text = "Логін надто довгий";
                LoginError.Visibility = Visibility.Visible;
                hasError = true;
            }

            // Пароль
            if (string.IsNullOrEmpty(password))
            {
                PasswordError.Text = "Невірний формат паролю";
                PasswordError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9!@#$%^&*()_\-+=\[\]{}|\\:;""'<>,.?/~`]+$"))
            {
                PasswordError.Text = "Пароль містить недопустимі символи";
                PasswordError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (password.Length < 8)
            {
                PasswordError.Text = "Пароль надто короткий";
                PasswordError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (password.Length > 32)
            {
                PasswordError.Text = "Пароль надто довгий";
                PasswordError.Visibility = Visibility.Visible;
                hasError = true;
            }

            // Дата народження
            if (!DateTime.TryParse(birth, out DateTime parsedDate))
            {
                BirthDateError.Text = "Невірний формат дати";
                BirthDateError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (parsedDate < new DateTime(1900, 1, 1))
            {
                BirthDateError.Text = "Не може бути раніше 1900 року";
                BirthDateError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (parsedDate >= DateTime.Now)
            {
                BirthDateError.Text = "Не може бути з майбутнього";
                BirthDateError.Visibility = Visibility.Visible;
                hasError = true;
            }

            // Телефон
            if (!phone.All(char.IsDigit))
            {
                PhoneError.Text = "Повинен містити лише цифри";
                PhoneError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (phone.Length != 10)
            {
                PhoneError.Text = "Має містити рівно 10 цифр";
                PhoneError.Visibility = Visibility.Visible;
                hasError = true;
            }
            else if (!phone.StartsWith("0"))
            {
                PhoneError.Text = "Повинен починатися з '0'";
                PhoneError.Visibility = Visibility.Visible;
                hasError = true;
            }

            if (!hasError)
            {
                if (AppData.Users.Any(u => u.Login == login))
                {
                    LoginError.Text = "Користувач з таким логіном вже існує";
                    LoginError.Visibility = Visibility.Visible;
                }
                else
                {
                    var newUser = new RegisteredUser(login, password, phone, parsedDate);
                    AppData.Users.Add(newUser);
                    AppData.CurrentUser = newUser;

                    JsonStorage.SaveUsers(AppData.Users);

                    MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

                    var mainMenu = new MainMenuWindow();
                    mainMenu.Show();
                    this.Close();
                }
            }

        }

        private void BackToLogin_Click(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
