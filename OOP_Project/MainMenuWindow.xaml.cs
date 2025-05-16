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
    }
}
