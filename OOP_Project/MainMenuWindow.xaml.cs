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
            DisplaySchedules();
            this.SearchBox.TextChanged += SearchBox_TextChanged;
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
            AddFilmModal.Visibility = Visibility.Visible;
        }


        private void CloseAddFilmModal_Click(object sender, RoutedEventArgs e)
        {
            AddFilmModal.Visibility = Visibility.Collapsed;
        }

        private void ConfirmAddFilm_Click(object sender, RoutedEventArgs e)
        {
            AddFilmErrorText.Text = "";
            AddFilmErrorText.Visibility = Visibility.Collapsed;
            bool hasError = false;

            string name = NameTextBox.Text;
            string yearText = YearTextBox.Text;
            string director = DirectorTextBox.Text;
            string language = LanguageTextBox.Text;
            string durationText = DurationTextBox.Text;
            string originalTitle = OriginalTitleTextBox.Text;
            string production = ProductionTextBox.Text;
            string studio = StudioTextBox.Text;
            string ageRestrictionText = AgeRestrictionTextBox.Text;
            string genre = GenreTextBox.Text;
            string description = DescriptionTextBox.Text;

            int year = 0;
            int ageRestriction = 0;
            int duration = 0;

            if (string.IsNullOrEmpty(name))
            {
                AddFilmErrorText.Text = "Назва фільму не може бути порожньою.";
                hasError = true;
            }
            else if (!int.TryParse(yearText, out year))
            {
                AddFilmErrorText.Text = "Рік має бути цілим числом.";
                hasError = true;
            }
            else if (year < 1900)
            {
                AddFilmErrorText.Text = "Рік не може бути раніше 1900.";
                hasError = true;
            }
            else if (string.IsNullOrEmpty(director))
            {
                AddFilmErrorText.Text = "Режисер не може бути порожнім.";
                hasError = true;
            }
            else if (string.IsNullOrEmpty(language))
            {
                AddFilmErrorText.Text = "Мова не може бути порожньою.";
                hasError = true;
            }
            else if (!int.TryParse(durationText, out duration))
            {
                AddFilmErrorText.Text = "Тривалість має бути цілим числом.";
                hasError = true;
            }
            else if (duration <= 0)
            {
                AddFilmErrorText.Text = "Тривалість має бути більшою за 0.";
                hasError = true;
            }
            else if (string.IsNullOrEmpty(originalTitle))
            {
                AddFilmErrorText.Text = "Оригінальна назва не може бути порожньою.";
                hasError = true;
            }
            else if (string.IsNullOrEmpty(production))
            {
                AddFilmErrorText.Text = "Виробництво не може бути порожнім.";
                hasError = true;
            }

            else if (string.IsNullOrEmpty(studio))
            {
                AddFilmErrorText.Text = "Студія не може бути порожньою.";
                hasError = true;
            }

            else if (!int.TryParse(ageRestrictionText, out ageRestriction))
            {
                AddFilmErrorText.Text = "Вікові обмеження мають бути числом.";
                hasError = true;
            }
            else if (ageRestriction < 0 || ageRestriction > 100)
            {
                AddFilmErrorText.Text = "Вікові обмеження мають бути в межах від 0 до 100.";
                hasError = true;
            }

            else if (string.IsNullOrEmpty(genre))
            {
                AddFilmErrorText.Text = "Жанр не може бути порожнім.";
                hasError = true;
            }

            else if (string.IsNullOrEmpty(description))
            {
                AddFilmErrorText.Text = "Опис не може бути порожнім.";
                hasError = true;
            }

            if (hasError)
            {
                AddFilmErrorText.Visibility = Visibility.Visible;
                return;
            }
            Film newFilm = new Film(name, ageRestriction, year, originalTitle, director, language, genre, duration, production, studio, description);
            ScreeningSchedule newSchedule = new ScreeningSchedule(newFilm);
            AppData.Schedules.Add(newSchedule);
            JsonStorage.SaveSchedules(AppData.Schedules);
            AddFilmModal.Visibility = Visibility.Collapsed;

            NameTextBox.Text = "Назва Фільму";
            YearTextBox.Text = "Рік";
            DirectorTextBox.Text = "Режисер";
            LanguageTextBox.Text = "Мова";
            DurationTextBox.Text = "Тривалість";
            OriginalTitleTextBox.Text = "Оригінальна Назва";
            ProductionTextBox.Text = "Виробництво";
            StudioTextBox.Text = "Студія";
            AgeRestrictionTextBox.Text = "Вікові обмеження";
            GenreTextBox.Text = "Жанр";
            DescriptionTextBox.Text = "Опис";
            DisplaySchedules();
        }

        private void AddScreening_Click(object sender, RoutedEventArgs e)
        {
            AddMenu.Visibility = Visibility.Collapsed;
            AddScreeningModal.Visibility = Visibility.Visible;

            FilmComboBox.ItemsSource = AppData.Schedules.Select(s => s.Film).ToList();
            FilmComboBox.DisplayMemberPath = "Name";
            FilmComboBox.SelectedIndex = -1;
        }

        private void CloseAddScreeningModal_Click(object sender, RoutedEventArgs e)
        {
            AddScreeningModal.Visibility = Visibility.Collapsed;
            FilmComboBox.SelectedItem = null;
            DateTextBox.Text = "Дата";
            TimeTextBox.Text = "Час";
            AddScreeningErrorText.Text = "";
        }

        private void ConfirmAddScreening_Click(object sender, RoutedEventArgs e)
        {
            AddScreeningErrorText.Visibility = Visibility.Collapsed;
            AddScreeningErrorText.Text = "";

            bool hasError = false;
            Film selectedFilm = FilmComboBox.SelectedItem as Film;

            if (selectedFilm == null)
            {
                AddScreeningErrorText.Text = "Фільм не було обрано.";
                hasError = true;
            }

            if (!DateTime.TryParse(DateTextBox.Text, out DateTime date))
            {
                AddScreeningErrorText.Text = "Неправильний формат дати.";
                hasError = true;
            }

            if (!TimeSpan.TryParse(TimeTextBox.Text, out TimeSpan time))
            {
                AddScreeningErrorText.Text = "Неправильний формат часу.";
                hasError = true;
            }

            if (hasError)
            {
                AddScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            DateTime fullDateTime = date.Date + time;

            if (fullDateTime <= DateTime.Now)
            {
                AddScreeningErrorText.Text = "Сеанс не може бути в минулому.";
                AddScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            if (fullDateTime > DateTime.Now.AddYears(1))
            {
                AddScreeningErrorText.Text = "Сеанс не може бути пізніше ніж через рік.";
                AddScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            TimeSpan openingTime = new(9, 0, 0);   // 09:00
            TimeSpan closingTime = new(22, 0, 0);  // 22:00
            TimeSpan screeningStart = time;
            TimeSpan screeningEnd = time.Add(TimeSpan.FromMinutes(selectedFilm.Duration));

            if (screeningStart < openingTime)
            {
                AddScreeningErrorText.Text = "Сеанс виходить за межі робочого часу (з 9:00).";
                AddScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            if (screeningEnd > closingTime)
            {
                AddScreeningErrorText.Text = "Сеанс виходить за межі робочого часу (до 22:00).";
                AddScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            var schedule = AppData.Schedules.FirstOrDefault(s => s.Film == selectedFilm);
            if (schedule != null)
            {
                foreach (var existing in schedule.Screenings)
                {
                    var startExisting = existing.Date;
                    var endExisting = startExisting.AddMinutes(existing.Film.Duration);

                    var startNew = fullDateTime.AddMinutes(-15);
                    var endNew = fullDateTime.AddMinutes(selectedFilm.Duration + 15);

                    if (startNew < endExisting && endNew > startExisting)
                    {
                        AddScreeningErrorText.Text = "Сеанс перетинається з іншим або не має 15 хвилин буфера.";
                        AddScreeningErrorText.Visibility = Visibility.Visible;
                        return;
                    }
                }

                var screening = new Screening(selectedFilm, fullDateTime);
                var tickets = TicketHelper.GenerateTicketsForScreening(screening, 7, 15);
                screening.AddTickets(tickets);
                schedule.Add(screening);

                JsonStorage.SaveSchedules(AppData.Schedules);

                AddScreeningModal.Visibility = Visibility.Collapsed;
                FilmComboBox.SelectedItem = null;
                DateTextBox.Text = "Дата";
                TimeTextBox.Text = "Час";
                AddScreeningErrorText.Text = "";

                DisplaySchedules();
            }
            else
            {
                AddScreeningErrorText.Text = "Не вдалося знайти розклад для цього фільму.";
                AddScreeningErrorText.Visibility = Visibility.Visible;
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteMenu.Visibility = Visibility.Visible;
        }

        private void CloseDeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            DeleteMenu.Visibility = Visibility.Collapsed;
        }
        private void DeleteScreening_Click(object sender, RoutedEventArgs e)
        {
            DeleteMenu.Visibility = Visibility.Collapsed;
            DeleteScreeningModal.Visibility = Visibility.Visible;

            var allScreenings = AppData.Schedules.SelectMany(s => s.Screenings).ToList();

            DeleteScreeningComboBox.ItemsSource = allScreenings;
            DeleteScreeningComboBox.SelectedIndex = -1;

        }

        private void DeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            DeleteMenu.Visibility = Visibility.Collapsed;

            DeleteFilmComboBox.ItemsSource = AppData.Schedules.Select(s => s.Film).ToList();
            DeleteFilmComboBox.DisplayMemberPath = "Name";
            DeleteFilmComboBox.SelectedIndex = -1;

            DeleteFilmModal.Visibility = Visibility.Visible;
        }

        private void CloseDeleteFilmModal_Click(object sender, RoutedEventArgs e)
        {
            DeleteFilmModal.Visibility = Visibility.Collapsed;
        }

        private void ConfirmDeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            DeleteFilmErrorText.Visibility = Visibility.Collapsed;
            DeleteFilmErrorText.Text = "";

            if (DeleteFilmComboBox.SelectedItem is not Film filmToDelete)
                return;

            var schedule = AppData.Schedules.FirstOrDefault(s => s.Film == filmToDelete);
            if (schedule == null)
                return;

            bool hasPurchasedTickets = schedule.Screenings
                .SelectMany(s => s.Tickets)
                .Any(t => t.Owner != null);

            if (hasPurchasedTickets)
            {
                DeleteFilmErrorText.Text = "Неможливо видалити фільм, бо є куплені квитки на сеанси.";
                DeleteFilmErrorText.Visibility = Visibility.Visible;
                return;
            }

            foreach (var screening in schedule.Screenings.ToList())
            {
                if (screening.Tickets is List<Ticket> ticketList)
                    ticketList.Clear();
            }

            if (schedule.Screenings is List<Screening> screeningList)
                screeningList.Clear();


            AppData.Schedules.Remove(schedule);

            JsonStorage.SaveSchedules(AppData.Schedules);
            DisplaySchedules();

            DeleteFilmModal.Visibility = Visibility.Collapsed;
        }

        private void CloseDeleteScreeningModal_Click(object sender, RoutedEventArgs e)
        {
            DeleteScreeningModal.Visibility = Visibility.Collapsed;
            DeleteScreeningErrorText.Text = "";
            DeleteScreeningErrorText.Visibility = Visibility.Collapsed;
        }

        private void ConfirmDeleteScreening_Click(object sender, RoutedEventArgs e)
        {
            DeleteScreeningErrorText.Text = "";
            DeleteScreeningErrorText.Visibility = Visibility.Collapsed;

            if (DeleteScreeningComboBox.SelectedItem is not Screening selectedScreening)
            {
                DeleteScreeningErrorText.Text = "Сеанс не обрано.";
                DeleteScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            bool hasPurchasedTickets = selectedScreening.Tickets.Any(t => t.Owner != null);
            if (hasPurchasedTickets)
            {
                DeleteScreeningErrorText.Text = "Неможливо видалити — квитки вже куплені.";
                DeleteScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

            var schedule = AppData.Schedules.FirstOrDefault(s => s.Film == selectedScreening.Film);
            schedule?.Remove(selectedScreening);

            JsonStorage.SaveSchedules(AppData.Schedules);
            DisplaySchedules();
            DeleteScreeningModal.Visibility = Visibility.Collapsed;
        }


        private void DisplaySchedules(List<ScreeningSchedule>? filtered = null)
        {
            ScheduleListPanel.Children.Clear();

            var schedulesToShow = (filtered ?? AppData.Schedules).Where(s => s.Screenings.Count > 0);

            foreach (var schedule in schedulesToShow)
            {
                var panel = new Border
                {
                    Margin = new Thickness(10),
                    CornerRadius = new CornerRadius(10),
                    Background = Brushes.GhostWhite,
                    Padding = new Thickness(10),
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Gray
                };

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                // Кнопка замовлення
                var orderButton = new Button
                {
                    Content = "Замовити",
                    FontFamily = new FontFamily("Georgia"),
                    FontWeight = FontWeights.Bold,
                    Padding = new Thickness(10, 5, 10, 5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Gray,
                    Background = Brushes.White,
                    Cursor = Cursors.Hand
                };
                orderButton.Resources.Add(typeof(Border), new Style(typeof(Border))
                {
                    Setters = { new Setter(Border.CornerRadiusProperty, new CornerRadius(8)) }
                });

                var centerStack = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(20, 0, 20, 0),
                    VerticalAlignment = VerticalAlignment.Center
                };

                var titleText = new TextBlock
                {
                    Text = schedule.Film.Name,
                    FontFamily = new FontFamily("Georgia"),
                    FontWeight = FontWeights.Bold,
                    FontSize = 16
                };

                string dateText = schedule.Screenings.Count > 0
                    ? $"Прем’єра - {schedule.Screenings.Min(s => s.Date).ToString("dd.MM")}"
                    : "Сеансів немає";

                var premiereText = new TextBlock
                {
                    Text = dateText,
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 14
                };

                centerStack.Children.Add(titleText);
                centerStack.Children.Add(premiereText);

                // Кнопка "Про фільм"
                var aboutButton = new Button
                {
                    Content = "Про фільм",
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 14,
                    Padding = new Thickness(10, 5, 10, 5),
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.Gray,
                    Background = Brushes.White,
                    Cursor = Cursors.Hand
                };
                aboutButton.Resources.Add(typeof(Border), new Style(typeof(Border))
                {
                    Setters = { new Setter(Border.CornerRadiusProperty, new CornerRadius(8)) }
                });

                // Події
                aboutButton.Click += (s, e) =>
                {
                    FilmTitleText.Text = schedule.Film.Name;
                    AgeText.Text = $"{schedule.Film.AgeRestriction}+";
                    YearText.Text = schedule.Film.Year.ToString();
                    OriginalTitleText.Text = schedule.Film.OriginalTitle;
                    DirectorText.Text = schedule.Film.Director;
                    LanguageText.Text = schedule.Film.Language;
                    GenreText.Text = schedule.Film.Genre;
                    DurationText.Text = $"{schedule.Film.Duration / 60}:{schedule.Film.Duration % 60:D2}";
                    ProductionText.Text = schedule.Film.Production;
                    StudioText.Text = schedule.Film.Studio;
                    DescriptionText.Text = schedule.Film.Description;

                    FilmInfoModal.Visibility = Visibility.Visible;
                };

                orderButton.Click += (s, e) =>
                {
                    var relevantScreenings = schedule.Screenings
                        .Where(s => s.Date > DateTime.Now)
                        .ToList();

                    SelectScreeningComboBox.ItemsSource = relevantScreenings;
                    SelectScreeningComboBox.DisplayMemberPath = "GetDateString";
                    SelectScreeningComboBox.SelectedIndex = -1;
                    SelectScreeningModal.Visibility = Visibility.Visible;
                };



                Grid.SetColumn(orderButton, 0);
                Grid.SetColumn(centerStack, 1);
                Grid.SetColumn(aboutButton, 2);

                grid.Children.Add(orderButton);
                grid.Children.Add(centerStack);
                grid.Children.Add(aboutButton);

                panel.Child = grid;
                ScheduleListPanel.Children.Add(panel);
            }
        }

        private void CloseSelectScreeningModal_Click(object sender, RoutedEventArgs e)
        {
            SelectScreeningModal.Visibility = Visibility.Collapsed;
            SelectScreeningErrorText.Text = "";
            SelectScreeningErrorText.Visibility = Visibility.Collapsed;
        }

        private void ConfirmSelectScreening_Click(object sender, RoutedEventArgs e)
        {
            if (SelectScreeningComboBox.SelectedItem is not Screening selectedScreening)
            {
                SelectScreeningErrorText.Text = "Сеанс не обрано.";
                SelectScreeningErrorText.Visibility = Visibility.Visible;
                return;
            }

                SelectScreeningModal.Visibility = Visibility.Collapsed;
            SelectScreeningErrorText.Visibility = Visibility.Collapsed;

            var ticketWindow = new TicketSelectionWindow(selectedScreening, this);
            this.Hide();
            ticketWindow.Show();
        }



        private void CloseFilmInfoModal_Click(object sender, RoutedEventArgs e)
        {
            FilmInfoModal.Visibility = Visibility.Collapsed;
            SelectScreeningErrorText.Visibility = Visibility.Collapsed;
        }

        private void CloseOrderConfirmationModal_Click(object sender, RoutedEventArgs e)
        {
            OrderConfirmationModal.Visibility = Visibility.Collapsed;
        }

        private void ConfirmOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderConfirmationModal.Visibility = Visibility.Collapsed;
        }

        private void CloseTicketsModal_Click(object sender, RoutedEventArgs e)
        {
            TicketsModal.Visibility = Visibility.Collapsed;
        }

        private void OpenTickets_Click(object sender, RoutedEventArgs e)
        {
            ProfilePopup.IsOpen = false;
            TicketListPanel.Children.Clear();

            foreach (var ticket in AppData.CurrentUser.PurchasedTickets)
            {
                var ticketBorder = new Border
                {
                    Margin = new Thickness(10),
                    Padding = new Thickness(10),
                    Background = Brushes.White,
                    BorderBrush = Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(8)
                };

                var stack = new StackPanel();

                stack.Children.Add(new TextBlock
                {
                    Text = $"Фільм: {ticket.Screening.Film.Name}",
                    FontFamily = new FontFamily("Georgia"),
                    FontWeight = FontWeights.Bold,
                    FontSize = 14
                });

                stack.Children.Add(new TextBlock
                {
                    Text = $"Дата: {ticket.Screening.Date:dd.MM.yyyy}  Час: {ticket.Screening.Date:HH:mm}",
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 13
                });

                stack.Children.Add(new TextBlock
                {
                    Text = $"Ряд: {ticket.Row}  Місце: {ticket.Seat}",
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 13
                });

                stack.Children.Add(new TextBlock
                {
                    Text = $"ID квитка: {ticket.TicketId}",
                    FontFamily = new FontFamily("Georgia"),
                    FontSize = 12,
                    Foreground = Brushes.Gray
                });

                ticketBorder.Child = stack;
                TicketListPanel.Children.Add(ticketBorder);
            }

            TicketsModal.Visibility = Visibility.Visible;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = SearchBox.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(query))
            {
                DisplaySchedules();
            }
            else
            {
                var filtered = AppData.Schedules
                    .Where(s => s.Film.Name.ToLower().StartsWith(query))
                    .ToList();

                DisplaySchedules(filtered);
            }
        }
    }
}
