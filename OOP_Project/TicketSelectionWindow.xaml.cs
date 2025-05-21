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
    /// Interaction logic for TicketSelectionWindow.xaml
    /// </summary>
    public partial class TicketSelectionWindow : Window
    {
        private Screening _screening;
        private MainMenuWindow _mainMenu;

        private const int Rows = 7;
        private const int Columns = 15;
        private const int SeatPrice = 200;

        private List<Button> seatButtons = new();
        private List<(int Row, int Seat)> selectedSeats = new();

        public TicketSelectionWindow(Screening screening, MainMenuWindow mainMenu)
        {
            InitializeComponent();
            _screening = screening;
            _mainMenu = mainMenu;

            FilmTitle.Text = screening.Film.Name;
            ScreeningDate.Text = "Дата: " + screening.Date.ToString("dd.MM.yyyy");
            ScreeningTime.Text = "Час: " + screening.Date.ToString("HH:mm");

            GenerateSeats();
            UpdateTotal();
        }


        private void GenerateSeats()
        {
            for (int row = 1; row <= Rows; row++)
            {
                for (int seat = 1; seat <= Columns; seat++)
                {
                    var button = new Button
                    {
                        Width = 25,
                        Height = 25,
                        Margin = new Thickness(2),
                        Background = Brushes.White,
                        BorderBrush = Brushes.Gray,
                        Tag = (row, seat)
                    };

                    var ticket = _screening.Tickets.FirstOrDefault(t => t.Row == row && t.Seat == seat);

                    if (ticket != null && ticket.Owner != null)
                    {
                        button.Background = new SolidColorBrush(Color.FromRgb(90, 90, 90));
                    }
                    else
                    {
                        button.Click += SeatButton_Click;
                    }

                    SeatsGrid.Children.Add(button);
                    seatButtons.Add(button);
                }
            }
        }


        private void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var (row, seat) = ((int, int))button.Tag;

            var seatInfo = (row, seat);
            if (selectedSeats.Contains(seatInfo))
            {
                selectedSeats.Remove(seatInfo);
                button.Background = Brushes.White;
            }
            else
            {
                selectedSeats.Add(seatInfo);
                button.Background = Brushes.LightGreen;
            }

            UpdateTotal();
            DisplaySelectedSeats();
        }

        private void UpdateTotal()
        {
            TotalText.Text = $"Всього до сплати: {selectedSeats.Count * SeatPrice} грн.";
        }

        private void DisplaySelectedSeats()
        {
            SelectedSeatsPanel.Items.Clear();
            foreach (var (row, seat) in selectedSeats)
            {
                SelectedSeatsPanel.Items.Add(new TextBlock
                {
                    Text = $"Ряд {row}, Місце {seat}",
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 14,
                    Margin = new Thickness(5)
                });
            }
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.CurrentUser == null)
            {
                MessageBox.Show("Гість не може купувати квитки. Будь ласка, увійдіть у систему.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(selectedSeats.Count() == 0)
            {
                MessageBox.Show("Місця не було обрано. Будь ласка, оберіть місце", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            foreach (var (row, seat) in selectedSeats)
            {
                var ticket = _screening.Tickets.FirstOrDefault(t => t.Row == row && t.Seat == seat);

                if (ticket != null && ticket.Owner == null)
                {
                    ticket.AssignToUser(AppData.CurrentUser);
                }
            }

            JsonStorage.SaveSchedules(AppData.Schedules);
            JsonStorage.SaveUsers(AppData.Users);
            MessageBox.Show("Квитки успішно замовлено!", "Вітаємо", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

            _mainMenu.Show();
        }

        //private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AppData.CurrentUser == null)
        //    {
        //        MessageBox.Show("Гість не може купувати квитки. Будь ласка, увійдіть у систему.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    int successCount = 0;
        //    int failCount = 0;
        //    StringBuilder errorMessages = new();

        //    foreach (var (row, seat) in selectedSeats)
        //    {
        //        var ticket = _screening.Tickets.FirstOrDefault(t => t.Row == row && t.Seat == seat);

        //        if (ticket == null)
        //        {
        //            failCount++;
        //            errorMessages.AppendLine($"Квиток не знайдено: ряд {row}, місце {seat}");
        //            continue;
        //        }

        //        if (ticket.Owner != null)
        //        {
        //            failCount++;
        //            errorMessages.AppendLine($"Місце вже зайняте: ряд {row}, місце {seat}");
        //            continue;
        //        }

        //        // Все добре — купуємо
        //        ticket.AssignToUser(AppData.CurrentUser);
        //        successCount++;
        //    }

        //    JsonStorage.SaveSchedules(AppData.Schedules);
        //    JsonStorage.SaveUsers(AppData.Users);

        //    if (failCount == 0)
        //    {
        //        MessageBox.Show("Квитки успішно замовлено!", "Вітаємо", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else if (successCount > 0)
        //    {
        //        MessageBox.Show($"Куплено {successCount} квитків.\nДеякі квитки не були куплені:\n\n{errorMessages}", "Частковий успіх", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //    else
        //    {
        //        MessageBox.Show($"Жоден квиток не був куплений:\n\n{errorMessages}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //    this.Close();
        //    _mainMenu.Show();
        //}


        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainMenuWindow();
            mainMenu.Show();
            this.Close();
        }

    }
}
