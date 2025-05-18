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

                    button.Click += SeatButton_Click;
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

            foreach (var (row, seat) in selectedSeats)
            {
                var ticket = _screening.Tickets.FirstOrDefault(t => t.Row == row && t.Seat == seat);
                if (ticket != null && ticket.Owner == null)
                {
                    ticket.AssignToUser(AppData.CurrentUser);
                }
            }

            JsonStorage.SaveSchedules(AppData.Schedules);
            MessageBox.Show("Квитки успішно замовлено!", "Вітаємо", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();

            _mainMenu.Show();
        }


        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            var mainMenu = new MainMenuWindow();
            mainMenu.Show();
            this.Close();
        }

    }
}
